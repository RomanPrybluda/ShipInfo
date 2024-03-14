using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateAuxiliaryEngineManufacturerDTO
    {
        public string? AuxiliaryEngineType { get; set; }

        public int MaxAuxiliaryEnginePower { get; set; }

        public int MaxAuxiliaryEngineSpeed { get; set; }

        public Guid AuxiliaryEngineManufacturerId { get; set; }

        public void UpdateAuxiliaryEngineManufacturer(
            AuxiliaryEngineManufacturer auxiliaryEngineManufacturer,
            UpdateAuxiliaryEngineManufacturerDTO auxiliaryEngineManufacturerDTO)
        {
            auxiliaryEngineManufacturer.Id = auxiliaryEngineManufacturerDTO.AuxiliaryEngineManufacturerId;

        }

    }
}