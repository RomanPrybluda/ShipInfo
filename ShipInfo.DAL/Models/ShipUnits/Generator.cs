namespace ShipInfo.DAL
{
    public class Generator : Base
    {
        public Guid Id { get; set; }

        public string? GeneratorType { get; set; }

        public int MaxGeneratorPower { get; set; }

        public int GeneratorVoltage { get; set; }

        public Guid GeneratorManufacturerId { get; set; }

        public GeneratorManufacturer? GeneratorManufacturer { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}