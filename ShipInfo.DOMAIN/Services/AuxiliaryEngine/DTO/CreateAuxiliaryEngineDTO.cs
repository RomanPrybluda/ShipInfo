using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateAuxiliaryEngineDTO
    {
        public string? AuxiliaryEngineType { get; set; }

        public int MaxAuxiliaryEnginePower { get; set; }

        public int MaxAuxiliaryEngineSpeed { get; set; }

        public Guid AuxiliaryEngineManufacturerId { get; set; }

        public static async Task<AuxiliaryEngine> ToAuxiliaryEngineAsync(CreateAuxiliaryEngineDTO auxiliaryEngineDTO)
        {
            return new AuxiliaryEngine
            {
                AuxiliaryEngineType = auxiliaryEngineDTO.AuxiliaryEngineType,
                MaxAuxiliaryEnginePower = auxiliaryEngineDTO.MaxAuxiliaryEnginePower,
                MaxAuxiliaryEngineSpeed = auxiliaryEngineDTO.MaxAuxiliaryEngineSpeed,
                AuxiliaryEngineManufacturerId = auxiliaryEngineDTO.AuxiliaryEngineManufacturerId
            };

        }
    }
}
