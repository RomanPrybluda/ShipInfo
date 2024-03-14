using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;
using ShipInfo.DOMAIN;
using ShipInfo.WebAPI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AccountService>();
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


builder.Services.AddIdentityCore<AppUser>().AddRoles<IdentityRole>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("ShipInfo.DAL"));
});

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

    var shipHullInitializer = new ShipHullInitializer(context);
    shipHullInitializer.InitializeShipHulls();

    var shipInitializer = new ShipInitializer(context);
    shipInitializer.InitializeShips();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.Run();