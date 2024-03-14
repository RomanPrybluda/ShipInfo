using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipFlagDTO
    {
        public string? ShipFlagName { get; set; }

        public void UpdateShipFlag(ShipFlag shipFlag, string shipFlagName)
        {
            shipFlag.ShipFlagName = shipFlagName;
        }

    }
}
