namespace ShipInfo.Domain.Entities
{
    public class GeneratorManufacturer
    {
        public Guid Id { get; set; }

        public string? GeneratorManufacturerName { get; set; }

        public ICollection<Generator>? Generators { get; set; }

    }
}