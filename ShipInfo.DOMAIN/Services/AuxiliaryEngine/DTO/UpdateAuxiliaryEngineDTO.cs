using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateAuxiliaryEngineDTO
    {

        public string? AuxiliaryEngineType { get; set; }

        public int MaxAuxiliaryEnginePower { get; set; }

        public int MaxAuxiliaryEngineSpeed { get; set; }

        public Guid AuxiliaryEngineManufacturerId { get; set; }

        public void UpdateAuxiliaryEngine(AuxiliaryEngine auxiliaryEngine, UpdateAuxiliaryEngineDTO auxiliaryEngineDTO)
        {

            auxiliaryEngine.AuxiliaryEngineType = auxiliaryEngineDTO.AuxiliaryEngineType;
            auxiliaryEngine.MaxAuxiliaryEnginePower = auxiliaryEngineDTO.MaxAuxiliaryEnginePower;
            auxiliaryEngine.MaxAuxiliaryEngineSpeed = auxiliaryEngineDTO.MaxAuxiliaryEngineSpeed;
            auxiliaryEngine.AuxiliaryEngineManufacturerId = auxiliaryEngineDTO.AuxiliaryEngineManufacturerId;

        }
    }
}
