using Bogus;
using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class OperatorInitializer
    {
        private readonly ShipInfoDbContext _context;

        public OperatorInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeOperators()
        {

            int needsOperatorsQuantity = 50;

            var faker = new Faker();

            var existingOperatorsCount = _context.Operators.Count();

            if (existingOperatorsCount >= needsOperatorsQuantity)
                return;

            else
            {
                for (int i = existingOperatorsCount; i < needsOperatorsQuantity - existingOperatorsCount; i++)
                {
                    var maxLength = 30;
                    var operatorName = GenerateEnglishOperatorName(faker);
                    var address = faker.Address.FullAddress();
                    var phoneNumber = faker.Phone.PhoneNumber("+1##########");
                    var email = faker.Internet.Email();

                    var operators = new Operator
                    {
                        OperatorName = operatorName.Length <= maxLength ? operatorName : operatorName.Substring(0, maxLength),
                        OperatorAddress = address,
                        OperatorEmail = email,
                        OperatorPhone = phoneNumber
                    };

                    _context.Operators.Add(operators);
                }

                _context.SaveChanges();
            }
        }

        private string GenerateEnglishOperatorName(Faker faker)
        {
            var random = new Random();
            int index = random.Next(EnglishOperatorNames.Length);
            return EnglishOperatorNames[index];
        }

        private string[] EnglishOperatorNames = new string[]
        {
            "Maritime Services Group",
            "Oceanic Logistics",
            "Seafarer Management Co.",
            "Pacific Seafaring Solutions",
            "Harbor Fleet Operations",
            "Bluewater Maritime",
            "Nautical Ventures Inc.",
            "WaveRunner Shipping",
            "Majestic Ocean Operations",
            "Global Marine Logistics",
            "SeaStar Fleet Management",
            "Coastwise Operations Ltd.",
            "Marine Dynamics Solutions",
            "Cruise Line Management",
            "Aqua Blue Shipping",
            "Sailor's Choice Maritime",
            "TransOceanic Services",
            "Starboard Logistics",
            "Horizon Maritime Solutions",
            "Captain's Crew Management",
            "DeepSea Operations",
            "MarineWave Logistics",
            "Windward Shipping Co.",
            "Pacific Pearl Fleet",
            "Golden Anchor Maritime",
            "Endless Sea Management",
            "Maritime Links Inc.",
            "BlueMarine Operations",
            "TradeWinds Shipping",
            "Great Lakes Fleet Services",
            "Sunset Marine Logistics",
            "Atlantic Maritime Group",
            "SailAway Ventures",
            "TideRunner Operations",
            "Oceanic Horizon Shipping",
            "North Star Fleet Management",
            "Seaborne Logistics",
            "Harmony Marine Solutions",
            "MarineVoyage Operations",
            "Mediterranean Seafaring",
            "MarineMaster Logistics",
            "CargoNet Fleet Management",
            "Pacific Wave Operations",
            "Sailor's Delight Shipping",
            "Coastwise Ventures",
            "Bluewave Maritime",
            "Nautical Express Management",
            "Maritime Alliance Solutions"
        };
    }
}