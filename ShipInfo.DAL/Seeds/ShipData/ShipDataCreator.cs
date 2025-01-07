using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class ShipDataCreator
    {
        private readonly ShipInfoDbContext _context;
        private static readonly Random _random = new Random();

        public ShipDataCreator(ShipInfoDbContext context)
        {
            _context = context;
        }

        public int GenerateImoNumbers()
        {
            Random random = new Random();

            int[] digits = new int[6];
            digits[0] = random.Next(8, 10);

            for (int j = 1; j < 6; j++)
                digits[j] = random.Next(0, 10);

            int checksum = CalculateImoChecksum(digits);
            digits[5] = checksum;
            int imoNumber = int.Parse(string.Join("", digits));

            return imoNumber;
        }

        public int CalculateImoChecksum(int[] digits)
        {
            int sum = 0;
            for (int i = 0; i < 6; i++)
                sum += digits[i] * (7 - i);

            return sum % 10;
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

            int range = (end - start).Days;
            return start.AddDays(_random.Next(range));
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

        public Guid GetShipPowerPlantTypeId(string powerPlantTypeName)
        {
            var shipPowerPlantTypeIds = _context.ShipPowerPlantTypes.Select(t => t.Id).ToList();
            var usedPowerPlantTypeIds = _context.Ships.Select(s => s.ShipPowerPlantTypeId).ToList();
            var availablePowerPlantTypeIds = shipPowerPlantTypeIds.Except(usedPowerPlantTypeIds).ToList();

            if (availablePowerPlantTypeIds.Any())
            {
                int randomIndex = _random.Next(availablePowerPlantTypeIds.Count);
                return availablePowerPlantTypeIds[randomIndex];
            }

            return Guid.Empty;
        }

        public Guid GetShipPropulsorTypeId(string powerPropulsorTypeName)
        {
            var shipPropulsorTypeIds = _context.ShipPropulsorTypes.Select(t => t.Id).ToList();
            var usedPropulsorTypeIds = _context.Ships.Select(s => s.ShipPropulsorTypeId).ToList();
            var availablePropulsorTypeIds = shipPropulsorTypeIds.Except(usedPropulsorTypeIds).ToList();

            if (availablePropulsorTypeIds.Any())
            {
                int randomIndex = _random.Next(availablePropulsorTypeIds.Count);
                return availablePropulsorTypeIds[randomIndex];
            }

            return Guid.Empty;
        }

    }
}