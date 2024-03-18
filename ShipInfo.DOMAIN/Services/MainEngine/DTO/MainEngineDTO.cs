using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class MainEngineDTO
    {
        public Guid Id { get; set; }

        public string? MainEngineType { get; set; }

        public int MaxMainEnginePower { get; set; }

        public int MaxMainEngineSpeed { get; set; }

        public Guid MainEngineManufacturerId { get; set; }

        public static MainEngineDTO ToMainEngineDTOAsync(MainEngine mainEngine)
        {
            return new MainEngineDTO
            {
                Id = mainEngine.Id,
                MainEngineType = mainEngine.MainEngineType,
                MaxMainEnginePower = mainEngine.MaxMainEnginePower,
                MaxMainEngineSpeed = mainEngine.MaxMainEngineSpeed,
                MainEngineManufacturerId = mainEngine.MainEngineManufacturerId
            };

        }
    }
}
