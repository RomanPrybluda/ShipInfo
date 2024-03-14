using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipFlagDTO
    {
        public string? ShipFlagName { get; set; }

        public static async Task<ShipFlag> ToShipFlagDTOAsync(CreateShipFlagDTO shipFlag)
        {
            return new ShipFlag
            {
                ShipFlagName = shipFlag.ShipFlagName
            };
        }
    }
}
