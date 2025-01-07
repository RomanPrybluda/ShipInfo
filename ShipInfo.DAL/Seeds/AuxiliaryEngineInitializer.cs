using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class AuxiliaryEngineInitializer
    {
        private readonly ShipInfoDbContext _context;
        private static readonly Random _random = new Random();

        public AuxiliaryEngineInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeAuxiliaryEngines()
        {
            var existingAuxiliaryEngineTypes = _context.AuxiliaryEngines.Select(ae => ae.AuxiliaryEngineType).ToList();
            var auxiliaryEnginesData = AuxiliaryEngineData();

            foreach (var auxiliaryEngineData in auxiliaryEnginesData)
            {
                if (!existingAuxiliaryEngineTypes.Contains(auxiliaryEngineData.AuxiliaryEngineType))
                {
                    var auxiliaryEngine = new AuxiliaryEngine
                    {
                        AuxiliaryEngineType = auxiliaryEngineData.AuxiliaryEngineType,
                        MaxAuxiliaryEnginePower = auxiliaryEngineData.MaxAuxiliaryEnginePower,
                        MaxAuxiliaryEngineSpeed = auxiliaryEngineData.MaxAuxiliaryEngineSpeed,
                        AuxiliaryEngineManufacturerId = GetRandomAuxiliaryEngineManufacturerId()
                    };

                    _context.AuxiliaryEngines.Add(auxiliaryEngine);
                }
            }

            _context.SaveChanges();
        }

        private (string AuxiliaryEngineType, int MaxAuxiliaryEnginePower, int MaxAuxiliaryEngineSpeed)[] AuxiliaryEngineData()
        {
            return new[]
            {
                ("DC-17", 441, 900), // mv SFERA
                ("6N18L-UN", 450, 720), // mv VIVA VESNA
                ("6N18AL-EV", 660, 900), // mv MOUNT OLYMPUS
                ("5DK-20", 530, 900), // mv NVL SIRIUS
                ("DK-20", 770, 720), // mv MLS ONYX
                ("6CTA8.3-GM155", 155, 1500), // mv LAURUS
                ("DNP12SI", 200, 1200), // mv NEVSKIY
                ("M200L-UT", 400, 720), // mv NOVAYA ZEMLYA
                ("6ЧН 18/22", 160, 750), // mv VELA
                ("6NSD-G", 441, 1200), // mv TOI CHALLENGER
                ("TD226B-6CD", 90, 1500),
                ("WP4CD66E200", 60, 1500),
                ("ДГРА 100/750-1ОМЗ", 100, 750)
            };
        }

        private Guid GetRandomAuxiliaryEngineManufacturerId()
        {
            var auxiliaryEngineManufacturers = _context.AuxiliaryEngineManufacturers.ToList();
            if (auxiliaryEngineManufacturers.Any())
            {
                int randomIndex = _random.Next(auxiliaryEngineManufacturers.Count);
                return auxiliaryEngineManufacturers[randomIndex].Id;
            }
            return Guid.Empty;
        }
    }
}
