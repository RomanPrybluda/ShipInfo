using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class AuxiliaryEngineDTO
    {
        public Guid Id { get; set; }

        public string? AuxiliaryEngineType { get; set; }

        public int MaxAuxiliaryEnginePower { get; set; }

        public int MaxAuxiliaryEngineSpeed { get; set; }

        public Guid AuxiliaryEngineManufacturerId { get; set; }

        public static async Task<AuxiliaryEngineDTO> ToAuxiliaryEngineDTOAsync(AuxiliaryEngine auxiliaryEngine)
        {
            return new AuxiliaryEngineDTO
            {
                Id = auxiliaryEngine.Id,
                AuxiliaryEngineType = auxiliaryEngine.AuxiliaryEngineType,
                MaxAuxiliaryEnginePower = auxiliaryEngine.MaxAuxiliaryEnginePower,
                MaxAuxiliaryEngineSpeed = auxiliaryEngine.MaxAuxiliaryEngineSpeed,
                AuxiliaryEngineManufacturerId = auxiliaryEngine.AuxiliaryEngineManufacturerId,
            };

        }

    }
}
