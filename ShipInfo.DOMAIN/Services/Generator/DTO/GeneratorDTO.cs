using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class GeneratorDTO
    {
        public Guid Id { get; set; }

        public string? GeneratorType { get; set; }

        public int MaxGeneratorPower { get; set; }

        public int GeneratorVoltage { get; set; }

        public Guid GeneratorManufacturerId { get; set; }

        public static async Task<GeneratorDTO> ToGeneratorDTOAsync(Generator generator)
        {
            return new GeneratorDTO
            {
                Id = generator.Id,
                GeneratorType = generator.GeneratorType,
                MaxGeneratorPower = generator.MaxGeneratorPower,
                GeneratorVoltage = generator.GeneratorVoltage,
                GeneratorManufacturerId = generator.GeneratorManufacturerId
            };

        }
    }
}
