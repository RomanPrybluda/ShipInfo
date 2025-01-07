using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class ShipFlagInitializer
    {
        private readonly ShipInfoDbContext _context;

        public ShipFlagInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeShipFlags()
        {
            var existingFlags = _context.ShipFlags.Select(cs => cs.ShipFlagName).ToList();

            var flagsToAdd = FlagsNames
                .Where(name => !existingFlags.Contains(name))
                .Select(name => new ShipFlag { ShipFlagName = name })
                .ToList();

            _context.ShipFlags.AddRange(flagsToAdd);
            _context.SaveChanges();
        }

        private string[] FlagsNames = new string[]
        {
            "Albania",
            "Algeria",
            "Antigua and Barbuda",
            "Azerbaijan",
            "Bahamas",
            "Bangladesh",
            "Barbados",
            "Belgium",
            "Belize",
            "Bolivia",
            "Cameroon",
            "Canada",
            "China People's Republic",
            "Taiwan",
            "Hong Kong, China",
            "Comoros",
            "Cook Islands",
            "Croatia",
            "Curacao",
            "Cyprus",
            "Denmark",
            "Faroe Islands",
            "Dominica",
            "Egypt",
            "Estonia",
            "Finland",
            "France",
            "Germany",
            "Greece",
            "India",
            "Indonesia",
            "Iran",
            "Ireland",
            "Italy",
            "Jamaica",
            "Japan",
            "Kiribati",
            "Korea",
            "Latvia",
            "Lebanon",
            "Liberia",
            "Lithuania",
            "Luxembourg",
            "Malaysia",
            "Malta",
            "Marshall Islands",
            "Moldova",
            "Mongolia",
            "Morocco",
            "Netherlands",
            "Niue",
            "Norway",
            "Palau",
            "Panama",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Russia",
            "Saudi Arabia",
            "Sierra Leone",
            "Singapore",
            "Spain",
            "St Vincent and Grenadines",
            "St.Kitts and Nevis",
            "Sweden",
            "Sweden",
            "Switzerland",
            "Tanzania",
            "Thailand",
            "Togo",
            "Turkey",
            "Tuvalu",
            "Ukraine",
            "United Kingdom",
            "Cayman Islands",
            "Isle of Man",
            "Gibraltar",
            "Bermuda",
            "United States of America",
            "Vanuatu",
            "Vietnam"
        };

    }
}