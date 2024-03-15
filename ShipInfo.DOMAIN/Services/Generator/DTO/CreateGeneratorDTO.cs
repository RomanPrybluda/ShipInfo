using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateGeneratorDTO
    {
        public Guid Id { get; set; }

        public string? GeneratorType { get; set; }

        public int MaxGeneratorPower { get; set; }

        public int GeneratorVoltage { get; set; }

        public Guid GeneratorManufacturerId { get; set; }

        public static async Task<Generator> ToGeneratorAsync(CreateGeneratorDTO createGeneratorDTO)
        {
            return new Generator
            {
                GeneratorType = createGeneratorDTO.GeneratorType,
                MaxGeneratorPower = createGeneratorDTO.MaxGeneratorPower,
                GeneratorVoltage = createGeneratorDTO.GeneratorVoltage,
                GeneratorManufacturerId = createGeneratorDTO.GeneratorManufacturerId
            };

        }
    }
}
