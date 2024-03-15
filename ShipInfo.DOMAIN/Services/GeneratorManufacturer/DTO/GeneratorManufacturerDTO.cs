using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class GeneratorManufacturerDTO
    {
        public Guid Id { get; set; }

        public string? GeneratorManufacturerName { get; set; }

        public static async Task<GeneratorManufacturerDTO> ToGeneratorManufacturerDTOAsync(GeneratorManufacturer generatorManufacturer)
        {
            return new GeneratorManufacturerDTO
            {
                Id = generatorManufacturer.Id,
                GeneratorManufacturerName = generatorManufacturer.GeneratorManufacturerName
            };

        }

    }
}