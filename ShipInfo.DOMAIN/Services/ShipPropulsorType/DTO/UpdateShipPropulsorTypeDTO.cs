using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipPropulsorTypeDTO
    {
        public string? ShipPropulsorTypeName { get; set; }

        public void UpdateShipPropulsorType(ShipPropulsorType shipPropulsorType, UpdateShipPropulsorTypeDTO updateShipPropulsorTypeDTO)
        {
            shipPropulsorType.ShipPropulsorTypeName = updateShipPropulsorTypeDTO.ShipPropulsorTypeName;
        }
    }
}
