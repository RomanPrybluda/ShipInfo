using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateMainEngineManufacturerDTO
    {
        public string? MainEngineManufacturerName { get; set; }

        public void UpdateMainEngineManufacturer(MainEngineManufacturer mainEngineManufacturer, UpdateMainEngineManufacturerDTO updateMainEngineManufacturerDTO)
        {
            mainEngineManufacturer.MainEngineManufacturerName = updateMainEngineManufacturerDTO.MainEngineManufacturerName;
        }

    }
}