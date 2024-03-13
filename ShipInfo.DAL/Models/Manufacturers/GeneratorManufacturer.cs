namespace ShipInfo.DAL
{
    public class GeneratorManufacturer : Base
    {
        public Guid Id { get; set; }

        public string? GeneratorManufacturerName { get; set; }

        public ICollection<Generator>? Generators { get; set; }

    }
}