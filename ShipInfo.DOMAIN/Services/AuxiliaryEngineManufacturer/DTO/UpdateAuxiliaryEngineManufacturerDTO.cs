using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateAuxiliaryEngineManufacturerDTO
    {
        public string? AuxiliaryEngineManufacturerName { get; set; }

        public void UpdateAuxiliaryEngineManufacturer(
            AuxiliaryEngineManufacturer auxiliaryEngineManufacturer,
            UpdateAuxiliaryEngineManufacturerDTO auxiliaryEngineManufacturerDTO)
        {
            auxiliaryEngineManufacturer.AuxiliaryEngineManufacturerName = auxiliaryEngineManufacturerDTO.AuxiliaryEngineManufacturerName;

        }

    }
}