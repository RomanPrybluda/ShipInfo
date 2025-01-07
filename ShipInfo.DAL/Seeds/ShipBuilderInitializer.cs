using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class ShipBuilderInitializer
    {
        private readonly ShipInfoDbContext _context;

        public ShipBuilderInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeShipBuilders()
        {
            var existingBuilders = _context.ShipBuilders.Select(b => b.ShipBuilderName).ToList();

            var buildersToAdd = BuilderNames
                .Where(name => !existingBuilders.Contains(name))
                .Select(name => new ShipBuilder { ShipBuilderName = name })
                .ToList();

            _context.ShipBuilders.AddRange(buildersToAdd);
            _context.SaveChanges();
        }


        private string[] BuilderNames = new string[]
        {
            "Daewoo Shipbuilding & Marine Engineering",
            "DSME",
            "Samsung Heavy Industries",
            "Hyundai Heavy Industries",
            "Hyundai Samho Heavy Industries",
            "Hyundai Mipo Dockyard",
            "Tsuneishi Shipbuilding",
            "Imabari Shipbuilding",
            "Shanghai Waigaoqiao Shipbuilding",
            "China Shipbuilding Industry Corporation",
            "Damen Group",
            "Mitsubishi Heavy Industries",
            "Mitsui Engineering & Shipbuilding",
            "Kawasaki Heavy Industries",
            "Meyer Werft",
            "Fincantieri",
            "Navantia",
            "Bath Iron Works",
            "Huntington Ingalls Industries",
            "Lockheed Martin",
            "BAE Systems",
            "General Dynamics",
            "Constructions Mécaniques de Normandie",
            "Hudong-Zhonghua Shipbuilding",
            "Cochin Shipyard",
            "GRSE",
            "Goa Shipyard Limited",
            "Naval Group",
            "ThyssenKrupp Marine Systems",
            "CameronShipbuilders",
            "Keppel Offshore & Marine",
            "Sembcorp Marine",
            "Vard Group",
            "Damen Shipyards Group",
            "Navantia",
            "IHI Corporation",
            "Sumitomo Heavy Industries",
            "STX Offshore & Shipbuilding",
            "Fujian Mawei Shipbuilding",
            "Zhoushan Changhong International Shipyard",
            "Yangzijiang Shipbuilding",
            "Jiangnan Shipyard",
            "CSBC Corporation",
            "Huangpu Wenchong Shipyard",
            "Nanjing Jinling Shipyard",
        };

    }
}