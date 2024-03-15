using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipPowerPlantTypeDTO
    {
        public string? ShipPowerPlantTypeName { get; set; }

        public void UpdateShipPowerPlantType(ShipPowerPlantType shipPowerPlantType, UpdateShipPowerPlantTypeDTO updateShipPowerPlantTypeDTO)
        {

            shipPowerPlantType.ShipPowerPlantTypeName = updateShipPowerPlantTypeDTO.ShipPowerPlantTypeName;


        }
    }
}
