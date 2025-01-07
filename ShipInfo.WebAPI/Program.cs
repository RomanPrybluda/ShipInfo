using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;
using ShipInfo.DAL.Repositories;
using ShipInfo.Domain;
using ShipInfo.Domain.Abstractions;
using ShipInfo.WebAPI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<ShipService>();

builder.Services.AddScoped<IShipRepository, ShipRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<ShipInfoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("ShipInfo.DAL"));
});

builder.Logging.AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShipInfoDbContext>();
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

    //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    //await RoleInitializer.InitializeRole(roleManager);

    //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    //var configuration = builder.Configuration;
    //await AdminInitializer.InitializeRole(userManager, configuration);

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();