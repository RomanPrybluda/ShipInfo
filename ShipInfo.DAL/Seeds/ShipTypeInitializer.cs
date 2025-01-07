using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class ShipTypeInitializer
    {
        private readonly ShipInfoDbContext _context;

        public ShipTypeInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeShipTypes()
        {
            foreach (var name in TypeNames)
            {
                var existingShipType = _context.ShipTypes.FirstOrDefault(st => st.ShipTypeName == name);

                if (existingShipType == null)
                {
                    _context.ShipTypes.Add(new ShipType { ShipTypeName = name });
                }
            }
            _context.SaveChanges();
        }

        private string[] TypeNames = new string[]
        {
            "Bulk Carrier",
            "Combination Carrier",
            "Container Ship",
            "Cruise Ship",
            "Gas Carrier",
            "General Cargo Ship",
            "LNG Carrier",
            "Refrigerated Cargo Carrier",
            "Ro-Ro Cargo Ship",
            "Ro-Ro Passenger Ship",
            "Ro-Ro Cargo Ship / Vehicle Carrier",
            "Ferry",
            "Icebreaker",
            "Oil Tanker",
            "Passenger Ship",
            "Tug"
        };
    }
}