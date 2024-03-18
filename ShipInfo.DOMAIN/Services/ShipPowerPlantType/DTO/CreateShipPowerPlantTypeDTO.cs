using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipPowerPlantTypeDTO
    {
        public string? ShipPowerPlantTypeName { get; set; }

        public static async Task<ShipPowerPlantType> ToShipPowerPlantTypeAsync(CreateShipPowerPlantTypeDTO createShipPowerPlantTypeDTO)
        {
            return new ShipPowerPlantType
            {
                ShipPowerPlantTypeName = createShipPowerPlantTypeDTO.ShipPowerPlantTypeName
            };

        }

    }
}