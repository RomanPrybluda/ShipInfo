using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateGeneratorManufacturerDTO
    {
        public string? GeneratorManufacturerName { get; set; }

        public void UpdateGeneratorManufacturer(GeneratorManufacturer generatorManufacturer, UpdateGeneratorManufacturerDTO updateGeneratorManufacturerDTO)
        {

            generatorManufacturer.GeneratorManufacturerName = updateGeneratorManufacturerDTO.GeneratorManufacturerName;

        }
    }
}
