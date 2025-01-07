using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class StatusInitializer
    {
        private readonly ShipInfoDbContext _context;

        public StatusInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeStatuses()
        {
            var existingStatuses = _context.Statuses.Select(x => x.StatusName).ToList();

            var statusesToAdd = StatusNames
                .Where(name => !existingStatuses.Contains(name))
                .Select(name => new Status { StatusName = name })
                .ToList();

            _context.Statuses.AddRange(statusesToAdd);
            _context.SaveChanges();
        }

        private string[] StatusNames = new string[]
        {
            "Broken Up",
            "Continued Existence In Doubt",
            "Converting/Rebuilding",
            "Hulked",
            "In Casualty Or Repairing",
            "In Service/Commission",
            "Laid-Up",
            "Launched",
            "Scuttled",
            "To Be Broken Up",
            "Total Loss",
            "U.S. Reserve Fleet"
        };
    }
}