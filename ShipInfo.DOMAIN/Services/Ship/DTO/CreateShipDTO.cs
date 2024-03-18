using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipDTO
    {

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public double GrossTonnage { get; set; }

        public Guid ShipFlagId { get; set; }

        public static Ship CreateShipDTOToShip(CreateShipDTO ship)
        {
            return new Ship
            {
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                DateOfBuild = ship.DateOfBuild,
                GrossTonnage = ship.GrossTonnage,
                ShipTypeId = ship.ShipTypeId,
                StatusId = ship.StatusId,
                ShipFlagId = ship.ShipFlagId
            };
        }

    }
}