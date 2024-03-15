using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class MainEngineManufacturerDTO
    {
        public Guid Id { get; set; }

        public string? MainEngineManufacturerName { get; set; }

        public static async Task<MainEngineManufacturerDTO> ToMainEngineManufacturerDTOAsync(MainEngineManufacturer mainEngineManufacturer)
        {
            return new MainEngineManufacturerDTO
            {
                Id = mainEngineManufacturer.Id,
                MainEngineManufacturerName = mainEngineManufacturer.MainEngineManufacturerName

            };

        }

    }
}