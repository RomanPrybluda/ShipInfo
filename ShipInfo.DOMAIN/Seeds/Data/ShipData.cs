using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipData
    {

        private readonly AppDbContext _context;
        private static readonly Random _random = new Random();
        private readonly int needsShipsQuantity = Constants.NeedsShipsQuantity;

        public int[] _imoNumbers;
        public int _nextImoIndex;

        public ShipData(AppDbContext context)
        {
            _context = context;
            _imoNumbers = GenerateUniqueImoNumbers(needsShipsQuantity);
            _nextImoIndex = 0;
        }

        public static readonly string[] ShipNames = new string[]
        {
            "Ocean Voyager", "Sea Explorer", "Marine Spirit", "Wave Rider",
            "Aqua Star", "Nautical Dream", "Blue Horizon", "Coastal Princess",
            "Island Navigator", "Harbor Master", "Sailor's Delight", "Tidal Quest",
            "Seafarer's Joy", "Coral Queen", "Voyage Vessel", "Majestic Mariner",
            "Seaside Serenity", "Aquatic Adventure", "Maritime Majesty", "Shipshape Splendor",
            "Oceanic Odyssey", "Seabreeze Bliss", "Seascape Symphony", "Marina Magic",
            "Bluewater Beauty", "Triton's Triumph", "Anchor's Away", "Seashell Serenade",
            "Sailaway Splendor", "Captain's Charm", "Nautical Nomad", "Maritime Marvel",
            "Salty Seafoam", "Seafaring Symphony", "Cruise King", "Ocean Pearl",
            "Tidal Treasure", "Mariner's Melody", "Seafarer's Solace", "Wavecrest Wonder",
            "Aquamarine Adventure", "Maritime Miracle", "Seaspray Splendor", "Sailor's Sanctuary",
            "Seabound Serenity", "Ocean Odyssey", "Voyage Voyager", "Coastal Cruiser",
            "Sailor's Sunrise", "Whale's Way",
            "Sea Serpent", "Golden Galleon", "Starlight Voyager", "Mighty Marlin",
            "Sunset Seafarer", "Whale's Bounty", "Crimson Corsair", "Azure Albatross",
            "Emerald Enchantment", "Vast Venture", "Silent Mermaid", "Thundering Typhoon",
            "Pirate's Plunder", "Windward Wanderer", "Crystal Crest", "Sapphire Siren",
            "Majestic Mermaid", "Crimson Kraken", "Sandy Schooner", "Ghostly Galleon",
            "Steel Shark", "Rising Phoenix", "Briny Buccaneer", "Celestial Cruiser",
            "Mystic Mariner", "Sapphire Starship", "Golden Gull", "Silver Swan",
            "Maritime Mirage", "Whispering Wave", "Dancing Dolphin", "Stellar Seafarer",
            "Arctic Aurora", "Twilight Tempest", "Coral Cove", "Whirlpool Wanderer",
            "Pearl Pirate", "Sunlit Seafarer", "Moonlit Mariner", "Midnight Mermaid",
            "Neptune's Nymph", "Treasure Trove", "Ocean Odyssey", "Voyage Vanguard",
            "Island Intruder", "Lunar Leviathan", "Sea Stallion", "Crimson Clipper",
            "Golden Goose", "Emerald Emissary", "Sapphire Seahorse", "Whispering Whale",
            "Sailor's Solitude", "Captain's Courage", "Maritime Medley", "Ocean Overture",
            "Voyage Virtuoso", "Twilight Tide", "Mystic Marlin", "Sunset Schooner",
            "Silver Serpent", "Crystal Cruiser", "Sandy Starship", "Neptune's Navy"
        };

        public static readonly string[] ShipTypes = new string[]
        {
            "Bulk Carrier",
            "Combination Carrier",
            "Container Ship",
            "General Cargo Ship",
            "Refrigerated Cargo Carrier"
        };

        public static readonly string[] ShipStatuses = new string[]
        {
            "In Casualty Or Repairing",
            "In Service/Commission"
        };

        public static readonly string[] powerPlantTypeName = new string[]
        {
            "Diesel Engine"
        };

        public static readonly string[] powerPropulsorTypeName = new string[]
        {
            "Fixed Pitch Propeller"
        };

        public int GetImoNumber()
        {
            if (_nextImoIndex >= _imoNumbers.Length)
                throw new InvalidOperationException("No more unique IMO numbers available.");

            return _imoNumbers[_nextImoIndex++];
        }

        public int[] GenerateUniqueImoNumbers(int needsShipsQuantity)
        {
            var uniqueImoNumbers = new HashSet<int>();

            while (uniqueImoNumbers.Count < needsShipsQuantity)
            {
                int[] digits = new int[7];
                digits[0] = _random.Next(7, 10);

                for (int j = 1; j < 6; j++)
                    digits[j] = _random.Next(0, 10);

                int checksum = 0;
                for (int i = 0; i < 6; i++)
                    checksum += digits[i] * (7 - i);

                checksum %= 10;
                digits[5] = checksum;

                digits[6] = (10 - (checksum % 10)) % 10;

                int imoNumber = int.Parse(string.Join("", digits));

                uniqueImoNumbers.Add(imoNumber);
            }

            return uniqueImoNumbers.ToArray();
        }


        public string GetShipName(string[] ShipNames)
        {
            int index = _random.Next(ShipNames.Length);
            string nextShipName = ShipNames[index];

            if (index < ShipNames.Length - 1)
            {
                ShipNames[index] = ShipNames[ShipNames.Length - 1];
                ShipNames[ShipNames.Length - 1] = nextShipName;
            }

            return nextShipName;
        }

        public Guid GetRandomShipTypeId(string[] ShipTypes)
        {
            var shipType = ShipTypes[_random.Next(ShipTypes.Length)];
            var shipTypeEntity = _context.ShipTypes.FirstOrDefault(st => st.ShipTypeName == shipType);
            return shipTypeEntity?.Id ?? Guid.Empty;
        }

        public Guid GetRandomStatusId(string[] ShipStatuses)
        {
            var matchingStatuses = _context.Statuses
                .Where(status => ShipStatuses.Contains(status.StatusName))
                .ToList();

            if (matchingStatuses.Any())
            {
                int randomIndex = _random.Next(matchingStatuses.Count);
                return matchingStatuses[randomIndex].Id;
            }

            return Guid.Empty;
        }

        public static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1996, 5, 3);
            DateTime end = new DateTime(2020, 6, 8);

            TimeSpan range = end - start;
            int totalDays = range.Days;

            int randomDays = _random.Next(totalDays);

            return start.AddDays(randomDays);
        }

        public string GenerateRandomCallSign(int callSingLenth)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            return new string(Enumerable.Repeat(chars, callSingLenth)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public T GetRandomEntity<T>(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            if (entityList.Any())
            {
                int randomIndex = _random.Next(entityList.Count);
                return entityList[randomIndex];
            }
            return default;
        }

        public Guid GetShipPowerPlantTypeId(string[] powerPlantTypeNames)
        {
            var matchingTypeIds = _context.ShipPowerPlantTypes
                .Where(t => powerPlantTypeNames.Contains(t.ShipPowerPlantTypeName))
                .Select(t => t.Id)
                .ToList();

            if (matchingTypeIds.Any())
            {
                int randomIndex = _random.Next(matchingTypeIds.Count);
                return matchingTypeIds[randomIndex];
            }

            return Guid.Empty;
        }

        public Guid GetShipPropulsorTypeId(string[] powerPropulsorTypeName)
        {
            var matchingTypeIds = _context.ShipPropulsorTypes
                .Where(t => powerPropulsorTypeName.Contains(t.ShipPropulsorTypeName))
                .Select(t => t.Id)
                .ToList();

            if (matchingTypeIds.Any())
            {
                int randomIndex = _random.Next(matchingTypeIds.Count);
                return matchingTypeIds[randomIndex];
            }

            return Guid.Empty;
        }

    }
}