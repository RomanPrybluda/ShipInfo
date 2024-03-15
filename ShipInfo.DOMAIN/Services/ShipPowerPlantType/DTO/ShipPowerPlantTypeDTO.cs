using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPowerPlantTypeDTO
    {
        public Guid Id { get; set; }

        public string? ShipPowerPlantTypeName { get; set; }

        public static async Task<ShipPowerPlantTypeDTO> ToShipPowerPlantTypeDTOAsync(ShipPowerPlantType shipPowerPlantType)
        {
            return new ShipPowerPlantTypeDTO
            {
                Id = shipPowerPlantType.Id,
                ShipPowerPlantTypeName = shipPowerPlantType.ShipPowerPlantTypeName
            };

        }

    }
}