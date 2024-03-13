using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPropulsorTypeInitializer
    {
        private readonly AppDbContext _context;

        public ShipPropulsorTypeInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeShipPropulsorTypes()
        {
            var existingTypes = _context.ShipPropulsorTypes.Select(pt => pt.ShipPropulsorTypeName).ToList();

            var typesToAdd = PropulsorTypeNames
                .Where(name => !existingTypes.Contains(name))
                .Select(name => new ShipPropulsorType { ShipPropulsorTypeName = name })
                .ToList();

            _context.ShipPropulsorTypes.AddRange(typesToAdd);
            _context.SaveChanges();
        }

        private string[] PropulsorTypeNames = new string[]
        {
            "Fixed Pitch Propeller",
            "Controllable Pitch Propeller",
            "Cycloidal Propeller",
            "Azimuth Thruster"
        };
    }
}