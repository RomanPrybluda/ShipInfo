using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPropulsorTypeDTO
    {
        public Guid Id { get; set; }

        public string? ShipPropulsorTypeName { get; set; }

        public static async Task<ShipPropulsorTypeDTO> ToShipPropulsorTypeDTOAsync(ShipPropulsorType shipPropulsorType)
        {
            return new ShipPropulsorTypeDTO
            {
                Id = shipPropulsorType.Id,
                ShipPropulsorTypeName = shipPropulsorType.ShipPropulsorTypeName

            };

        }
    }
}
