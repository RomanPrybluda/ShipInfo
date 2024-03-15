using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipPropulsorTypeDTO
    {
        public string? ShipPropulsorTypeName { get; set; }

        public static async Task<ShipPropulsorType> ToShipPropulsorTypeAsync(CreateShipPropulsorTypeDTO createShipPropulsorTypeDTO)
        {
            return new ShipPropulsorType
            {
                ShipPropulsorTypeName = createShipPropulsorTypeDTO.ShipPropulsorTypeName

            };

        }
    }
}
