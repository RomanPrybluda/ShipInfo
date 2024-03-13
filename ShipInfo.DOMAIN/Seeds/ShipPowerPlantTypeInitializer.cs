using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPowerPlantTypeInitializer
    {
        private readonly AppDbContext _context;

        public ShipPowerPlantTypeInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializePowerPlantTypes()
        {
            var existingTypes = _context.ShipPowerPlantTypes.Select(pt => pt.ShipPowerPlantTypeName).ToList();

            var typesToAdd = PlantTypeNames
                .Where(name => !existingTypes.Contains(name))
                .Select(name => new ShipPowerPlantType { ShipPowerPlantTypeName = name })
                .ToList();

            _context.ShipPowerPlantTypes.AddRange(typesToAdd);
            _context.SaveChanges();
        }

        private string[] PlantTypeNames = new string[]
        {
            "Diesel Engine",
            "Steam Turbine",
            "Gas Turbine",
            "Nuclear"
        };
    }
}