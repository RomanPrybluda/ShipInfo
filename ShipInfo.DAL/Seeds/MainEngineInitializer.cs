using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class MainEngineInitializer
    {
        private readonly ShipInfoDbContext _context;
        private static readonly Random _random = new Random();

        public MainEngineInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeMainEngines()
        {
            var existingMainEngineTypes = _context.MainEngines.Select(me => me.MainEngineType).ToList();
            var mainEnginesData = MainEngineData();

            foreach (var mainEngineData in mainEnginesData)
            {
                if (!existingMainEngineTypes.Contains(mainEngineData.MainEngineType))
                {
                    var mainEngine = new MainEngine
                    {
                        MainEngineType = mainEngineData.MainEngineType,
                        MaxMainEnginePower = mainEngineData.MaxMainEnginePower,
                        MaxMainEngineSpeed = mainEngineData.MaxMainEngineSpeed,
                        MainEngineManufacturerId = GetRandomMainEngineManufacturerId()
                    };

                    _context.MainEngines.Add(mainEngine);
                }
            }

            _context.SaveChanges();
        }

        private (string MainEngineType, int MaxMainEnginePower, int MaxMainEngineSpeed)[] MainEngineData()
        {
            return new[]
            {
                ("7S50MC-C", 9230, 106), // mv SFERA
                ("6S60MC", 8826, 94), // mv VIVA VESNA
                ("6UEC52LS", 7980, 120), // mv MOUNT OLYMPUS
                ("MAN-B&W 6S50MC-C", 8580, 127), // mv NVL SIRIUS
                ("6S50MCC (MK VII)", 9480, 127), // mv MLS ONYX
                ("G8300ZC16B-1", 1765, 525), // mv LAURUS
                ("5-K-45-GFC", 3312, 227), // mv NEVSKIY
                ("5UEC45LA", 4001, 106), // mv NOVAYA ZEMLYA
                ("8NVDS 48A‐3U", 970, 428), // mv VELA
                ("7S35 MC-MK6", 4891, 127), // mv TOI CHALLENGER
                ("HITACHI-B&W 6S50MC (MARK V)", 7281, 108),
                ("Sulzer 5RT-flex50", 5860, 86),
                ("Wärtsilä 12V32", 6400, 750),
                ("6NVD 48A-2U", 515, 310),
                ("8NVD48A-2U", 852, 375),
                ("8320ZCd-6", 2060, 525),
                ("9 M32", 3960, 600),
                ("6UEC52LS", 7980, 120),
            };
        }


        private Guid GetRandomMainEngineManufacturerId()
        {
            var mainEngineManufacturers = _context.MainEngineManufacturers.ToList();
            if (mainEngineManufacturers.Any())
            {
                int randomIndex = _random.Next(mainEngineManufacturers.Count);
                return mainEngineManufacturers[randomIndex].Id;
            }
            return Guid.Empty;
        }
    }
}
