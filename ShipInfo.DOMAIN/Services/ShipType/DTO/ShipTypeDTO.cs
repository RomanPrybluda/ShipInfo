using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipTypeDTO
    {
        public Guid Id { get; set; }

        public string? ShipTypeName { get; set; }

        public static async Task<ShipTypeDTO> ToShipTypeDTOAsync(ShipType shipType)
        {
            return new ShipTypeDTO
            {
                Id = shipType.Id,
                ShipTypeName = shipType.ShipTypeName

            };

        }
    }
}
