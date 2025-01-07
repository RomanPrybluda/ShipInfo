using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class AuxiliaryEngineManufacturerInitializer
    {
        private readonly ShipInfoDbContext _context;

        public AuxiliaryEngineManufacturerInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeAuxiliaryEngineManufacturers()
        {
            var existingManufacturers = _context.AuxiliaryEngineManufacturers.Select(m => m.AuxiliaryEngineManufacturerName).ToList();

            var manufacturersToAdd = ManufacturerNames
                .Where(name => !existingManufacturers.Contains(name))
                .Select(name => new AuxiliaryEngineManufacturer { AuxiliaryEngineManufacturerName = name })
                .ToList();

            _context.AuxiliaryEngineManufacturers.AddRange(manufacturersToAdd);
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
