using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipDTO
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public static async Task<Ship> ToShipAsync(CreateShipDTO ship)
        {
            return new Ship
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                DateOfBuild = ship.DateOfBuild,
                GrossTonnage = ship.GrossTonnage,
                SummerDeadweight = ship.SummerDeadweight,
                ShipTypeId = ship.ShipTypeId,
                StatusId = ship.StatusId
            };
        }

    }
}