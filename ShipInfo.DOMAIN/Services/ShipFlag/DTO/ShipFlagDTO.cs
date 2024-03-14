using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipFlagDTO
    {
        public Guid Id { get; set; }

        public string? ShipFlagName { get; set; }

        public static async Task<ShipFlagDTO> ToShipFlagDTOAsync(ShipFlag shipFlag)
        {
            return new ShipFlagDTO
            {
                Id = shipFlag.Id,
                ShipFlagName = shipFlag.ShipFlagName

            };

        }
    }
}
