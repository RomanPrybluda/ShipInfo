using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;
using ShipInfo.DOMAIN;
using ShipInfo.WebAPI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("Default");

var localConnectionString = builder.Configuration["ConnectionStrings:LocalConnectionString"];

if (!string.IsNullOrWhiteSpace(localConnectionString))
{
    connectionString = localConnectionString;
}

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string is not set. Check environment variables, appsettings.json, or secrets.");
}


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<RoleService>();

builder.Services.AddScoped<AuxiliaryEngineService>();
builder.Services.AddScoped<AuxiliaryEngineManufacturerService>();
builder.Services.AddScoped<ClassSocietyService>();
builder.Services.AddScoped<GeneratorService>();
builder.Services.AddScoped<GeneratorManufacturerService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<MainEngineService>();
builder.Services.AddScoped<MainEngineManufacturerService>();
builder.Services.AddScoped<OperatorService>();
builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<ShipService>();
builder.Services.AddScoped<ShipBuilderService>();
builder.Services.AddScoped<ShipFlagService>();
builder.Services.AddScoped<ShipPowerPlantTypeService>();
builder.Services.AddScoped<ShipPropulsorTypeService>();
builder.Services.AddScoped<ShipTypeService>();
builder.Services.AddScoped<StatusService>();


builder.Services.AddIdentityCore<AppUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ShipInfo.DAL"));
});


builder.Logging.AddConsole();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    var shipTypeInitializer = new ShipTypeInitializer(context);
    shipTypeInitializer.InitializeShipTypes();

    var shipPropulsorTypeInitializer = new ShipPropulsorTypeInitializer(context);
    shipPropulsorTypeInitializer.InitializeShipPropulsorTypes();

    var shipPowerPlantTypeInitializer = new ShipPowerPlantTypeInitializer(context);
    shipPowerPlantTypeInitializer.InitializePowerPlantTypes();

    var mainEngineManufacturerInitializer = new MainEngineManufacturerInitializer(context);
    mainEngineManufacturerInitializer.InitializeMainEngineManufacturers();

    var auxiliaryEngineManufacturerInitializer = new AuxiliaryEngineManufacturerInitializer(context);
    auxiliaryEngineManufacturerInitializer.InitializeAuxiliaryEngineManufacturers();

    var generatorManufacturerInitializer = new GeneratorManufacturerInitializer(context);
    generatorManufacturerInitializer.InitializeGeneratorManufacturers();

    var mainEngineInitializer = new MainEngineInitializer(context);
    mainEngineInitializer.InitializeMainEngines();

    var auxiliaryEngineInitializer = new AuxiliaryEngineInitializer(context);
    auxiliaryEngineInitializer.InitializeAuxiliaryEngines();

    var generatorInitializer = new GeneratorInitializer(context);
    generatorInitializer.InitializeGenerators();

    var shipBuilderInitializer = new ShipBuilderInitializer(context);
    shipBuilderInitializer.InitializeShipBuilders();

    var classSocietyInitializer = new ClassSocietyInitializer(context);
    classSocietyInitializer.InitializeClassSocieties();

    var statusInitializer = new StatusInitializer(context);
    statusInitializer.InitializeStatuses();

    var shipFlagInitializer = new ShipFlagInitializer(context);
    shipFlagInitializer.InitializeShipFlags();

    var ownerInitializer = new OwnerInitializer(context);
    ownerInitializer.InitializeOwners();

    var operatorInitializer = new OperatorInitializer(context);
    operatorInitializer.InitializeOperators();

    var shipInitializer = new ShipInitializer(context);
    shipInitializer.InitializeShips();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleInitializer.InitializeRole(roleManager);

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var configuration = builder.Configuration;
    await AdminInitializer.InitializeRole(userManager, configuration);

}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
// Swagger will be available also on production hosting
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();