using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipTypeDTO
    {
        public string? ShipTypeName { get; set; }

        public static async Task<ShipType> ToShipTypeAsync(CreateShipTypeDTO shipTypeDTO)
        {
            return new ShipType
            {
                ShipTypeName = shipTypeDTO.ShipTypeName
            };
        }
    }
}
