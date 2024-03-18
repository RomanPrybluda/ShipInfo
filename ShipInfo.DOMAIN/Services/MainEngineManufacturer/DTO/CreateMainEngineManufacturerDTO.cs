using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateMainEngineManufacturerDTO
    {
        public string? MainEngineManufacturerName { get; set; }

        public static async Task<MainEngineManufacturer> ToMainEngineManufacturerAsync(
            CreateMainEngineManufacturerDTO createMainEngineManufacturerDTO)
        {
            return new MainEngineManufacturer
            {
                MainEngineManufacturerName = createMainEngineManufacturerDTO.MainEngineManufacturerName
            };

        }

    }
}