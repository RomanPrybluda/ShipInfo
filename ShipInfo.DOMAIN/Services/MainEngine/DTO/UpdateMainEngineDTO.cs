using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateMainEngineDTO
    {
        public string? MainEngineType { get; set; }

        public int MaxMainEnginePower { get; set; }

        public int MaxMainEngineSpeed { get; set; }

        public Guid MainEngineManufacturerId { get; set; }

        public void UpdateMainEngine(MainEngine mainEngine, UpdateMainEngineDTO updateMainEngineDTO)
        {
            mainEngine.MainEngineType = updateMainEngineDTO.MainEngineType;
            mainEngine.MaxMainEnginePower = updateMainEngineDTO.MaxMainEnginePower;
            mainEngine.MaxMainEngineSpeed = updateMainEngineDTO.MaxMainEngineSpeed;
            mainEngine.MainEngineManufacturerId = updateMainEngineDTO.MainEngineManufacturerId;
        }
    }
}