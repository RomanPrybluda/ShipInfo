using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateMainEngineDTO
    {
        public string? MainEngineType { get; set; }

        public int MaxMainEnginePower { get; set; }

        public int MaxMainEngineSpeed { get; set; }

        public Guid MainEngineManufacturerId { get; set; }

        public static MainEngine ToMainEngineAsync(CreateMainEngineDTO mainEngine)
        {
            return new MainEngine
            {

                MainEngineType = mainEngine.MainEngineType,
                MaxMainEnginePower = mainEngine.MaxMainEnginePower,
                MaxMainEngineSpeed = mainEngine.MaxMainEngineSpeed,
                MainEngineManufacturerId = mainEngine.MainEngineManufacturerId
            };

        }
    }
}
