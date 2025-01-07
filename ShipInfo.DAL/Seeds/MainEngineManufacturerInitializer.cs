using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class MainEngineManufacturerInitializer
    {
        private readonly ShipInfoDbContext _context;

        public MainEngineManufacturerInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeMainEngineManufacturers()
        {
            var existingManufacturers = _context.MainEngineManufacturers.Select(m => m.MainEngineManufacturerName).ToList();

            var manufacturersToAdd = ManufacturerNames
                .Where(name => !existingManufacturers.Contains(name))
                .Select(name => new MainEngineManufacturer { MainEngineManufacturerName = name })
                .ToList();

            _context.MainEngineManufacturers.AddRange(manufacturersToAdd);
            _context.SaveChanges();
        }

        private string[] ManufacturerNames = new string[]
        {
            "ABB Turbo Systems Ltd",
            "Caterpillar Motoren GmbH & Co. KG",
            "China Shipbuilding Industry Corporation",
            "Cummins Inc.",
            "Daihatsu Diesel Mfg. Co. Ltd.",
            "Deutz AG",
            "Doosan Engine Co. Ltd.",
            "GE Transportation",
            "Gottwald Port Technology GmbH",
            "Guangzhou Diesel Engine Factory Co. Ltd.",
            "Hanshin Diesel Works Ltd.",
            "Hyundai Heavy Industries Co. Ltd.",
            "Isotta Fraschini Motori SpA",
            "JFE Engineering Corporation",
            "Kawasaki Heavy Industries Ltd.",
            "Komatsu Ltd.",
            "Liebherr",
            "Mitsubishi Heavy Industries Ltd.",
            "MTU Friedrichshafen GmbH",
            "Niigata Power Systems Co. Ltd.",
            "Rolls-Royce plc",
            "S.E.M.T. Pielstick",
            "Wärtsilä Corporation",
            "Yanmar Co. Ltd."
        };
    }
}