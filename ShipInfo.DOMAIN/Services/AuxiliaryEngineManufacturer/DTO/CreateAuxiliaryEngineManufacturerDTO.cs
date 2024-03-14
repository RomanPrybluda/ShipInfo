using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateAuxiliaryEngineManufacturerDTO
    {
        public string? AuxiliaryEngineManufacturerName { get; set; }

        public static async Task<AuxiliaryEngineManufacturer> ToAuxiliaryEngineManufacturerAsync(
            CreateAuxiliaryEngineManufacturerDTO auxiliaryEngineManufacturerDTO)
        {
            return new AuxiliaryEngineManufacturer
            {
                AuxiliaryEngineManufacturerName = auxiliaryEngineManufacturerDTO.AuxiliaryEngineManufacturerName
            };
        }

    }
}
