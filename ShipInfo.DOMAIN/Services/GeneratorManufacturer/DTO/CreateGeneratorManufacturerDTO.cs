using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateGeneratorManufacturerDTO
    {
        public string? GeneratorManufacturerName { get; set; }

        public static async Task<GeneratorManufacturer> ToGeneratorManufacturerAsync(CreateGeneratorManufacturerDTO generatorManufacturerDTO)
        {
            return new GeneratorManufacturer
            {
                GeneratorManufacturerName = generatorManufacturerDTO.GeneratorManufacturerName
            };

        }

    }
}