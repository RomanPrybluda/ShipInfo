using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class AuxiliaryEngineManufacturerDTO
    {
        public Guid Id { get; set; }

        public string? AuxiliaryEngineManufacturerName { get; set; }

        public static async Task<AuxiliaryEngineManufacturerDTO> ToAuxiliaryEngineManufacturerDTOAsync(AuxiliaryEngineManufacturer auxiliaryEngineManufacturer)
        {
            return new AuxiliaryEngineManufacturerDTO
            {
                Id = auxiliaryEngineManufacturer.Id,
                AuxiliaryEngineManufacturerName = auxiliaryEngineManufacturer.AuxiliaryEngineManufacturerName
            };

        }
    }
}
