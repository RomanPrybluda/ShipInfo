using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class GeneratorInitializer
    {
        private readonly AppDbContext _context;
        private static readonly Random _random = new Random();

        public GeneratorInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeGenerators()
        {
            var existingGeneratorTypes = _context.Generators.Select(g => g.GeneratorType).ToList();
            var generatorsData = GeneratorData();

            foreach (var generatorData in generatorsData)
            {
                if (!existingGeneratorTypes.Contains(generatorData.GeneratorType))
                {
                    var generator = new Generator
                    {
                        GeneratorType = generatorData.GeneratorType,
                        MaxGeneratorPower = generatorData.MaxGeneratorPower,
                        GeneratorVoltage = generatorData.GeneratorVoltage,
                        GeneratorManufacturerId = GetRandomGeneratorManufacturerId()
                    };

                    _context.Generators.Add(generator);
                }
            }

            _context.SaveChanges();
        }

        private (string GeneratorType, int MaxGeneratorPower, int GeneratorVoltage)[] GeneratorData()
        {
            return new[]
            {
                ("AC", 400, 450), // mv SFERA
                ("AC", 400, 450), // mv VIVA VESNA
                ("AC", 600, 450), // mv MOUNT OLYMPUS
                ("AC", 480, 450), // mv NVL SIRIUS
                ("AC", 680, 450), // mv MLS ONYX
                ("AC", 120, 380), // mv LAURUS
                ("AC", 200, 450), // mv NEVSKIY
                ("AC", 400, 445), // mv NOVAYA ZEMLYA
                ("AC", 160, 400), // mv VELA
                ("AC", 400, 450), // mv TOI CHALLENGER
            };
        }


        private Guid GetRandomGeneratorManufacturerId()
        {
            var generatorManufacturers = _context.GeneratorManufacturers.ToList();
            if (generatorManufacturers.Any())
            {
                int randomIndex = _random.Next(generatorManufacturers.Count);
                return generatorManufacturers[randomIndex].Id;
            }
            return Guid.Empty;
        }
    }
}
