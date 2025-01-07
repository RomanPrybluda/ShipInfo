using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class GeneratorManufacturerInitializer
    {
        private readonly ShipInfoDbContext _context;

        public GeneratorManufacturerInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeGeneratorManufacturers()
        {
            var existingManufacturers = _context.GeneratorManufacturers.Select(m => m.GeneratorManufacturerName).ToList();

            var manufacturersToAdd = ManufacturerNames
                .Where(name => !existingManufacturers.Contains(name))
                .Select(name => new GeneratorManufacturer { GeneratorManufacturerName = name })
                .ToList();

            _context.GeneratorManufacturers.AddRange(manufacturersToAdd);
            _context.SaveChanges();
        }

        private string[] ManufacturerNames = new string[]
        {
            "ABB",
            "Caterpillar",
            "Cummins",
            "Doosan",
            "Generac Power Systems",
            "Himoinsa",
            "Kohler Power",
            "Mitsubishi Heavy Industries",
            "MTU Onsite Energy",
            "Perkins",
            "Rolls-Royce Power Systems",
            "Siemens",
            "Wärtsilä"
        };
    }
}