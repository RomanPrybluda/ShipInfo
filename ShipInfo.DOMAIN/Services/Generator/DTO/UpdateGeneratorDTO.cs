using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateGeneratorDTO
    {

        public string? GeneratorType { get; set; }

        public int MaxGeneratorPower { get; set; }

        public int GeneratorVoltage { get; set; }

        public Guid GeneratorManufacturerId { get; set; }

        public void UpdateGenerator(Generator generator, UpdateGeneratorDTO updateGeneratorDTO)
        {
            generator.GeneratorType = updateGeneratorDTO.GeneratorType;
            generator.MaxGeneratorPower = updateGeneratorDTO.MaxGeneratorPower;
            generator.GeneratorVoltage = updateGeneratorDTO.GeneratorVoltage;
            generator.GeneratorManufacturerId = updateGeneratorDTO.GeneratorManufacturerId;

        }
    }
}
