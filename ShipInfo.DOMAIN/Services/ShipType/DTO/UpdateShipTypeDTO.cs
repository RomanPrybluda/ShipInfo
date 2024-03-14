using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipTypeDTO
    {
        public string? ShipTypeName { get; set; }

        public void UpdateShipType(ShipType shipType, string shipTypeName)
        {
            shipType.ShipTypeName = shipTypeName;
        }

    }
}
