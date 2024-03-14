
namespace ShipInfo.DOMAIN
{
    public enum CustomExceptionType
    {
        InternalError = 1,
        NoContent = 2,
        NotFound = 3,
        InvalidInputData = 4,
        UserIsAlreadyExists = 5,
        ShipAlreadyExist = 6,
        ClassSocietyAlreadyExist = 7,
        ShipTypeAlreadyExists = 8,
        ShipFlagAlreadyExists = 9,
        StatusAlreadyExists = 10,
        ShipPropulsorTypeAlreadyExists = 11,
        ShipPowerPlantTypeAlreadyExists = 12,
        ShipBuilderAlreadyExists = 13,
        OwnerAlreadyExists = 14,
        OperatorAlreadyExists = 15,
        MainEngineManufacturerAlreadyExists = 16,
        MainEngineAlreadyExists = 17,
        GeneratorManufacturerAlreadyExists = 18,
        GeneratorAlreadyExists = 19,
        AuxiliaryEngineAlreadyExists = 20,
        AuxiliaryEngineManufacturerAlreadyExists = 21
    }
}
