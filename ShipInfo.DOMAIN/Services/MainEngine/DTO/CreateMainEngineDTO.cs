using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateMainEngineDTO
    {
        public string? MainEngineType { get; set; }

        public int MaxMainEnginePower { get; set; }

        public int MaxMainEngineSpeed { get; set; }

        public Guid MainEngineManufacturerId { get; set; }

        public static async Task<MainEngine> ToMainEngineAsync(CreateMainEngineDTO createMainEngineDTO)
        {
            return new MainEngine
            {

                MainEngineType = createMainEngineDTO.MainEngineType,
                MaxMainEnginePower = createMainEngineDTO.MaxMainEnginePower,
                MaxMainEngineSpeed = createMainEngineDTO.MaxMainEngineSpeed,
                MainEngineManufacturerId = createMainEngineDTO.MainEngineManufacturerId
            };

        }
    }
}
