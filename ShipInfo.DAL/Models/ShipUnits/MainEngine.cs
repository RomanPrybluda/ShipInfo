namespace ShipInfo.DAL
{
    public class MainEngine : Base
    {
        public Guid Id { get; set; }

        public string? MainEngineType { get; set; }

        public int MaxMainEnginePower { get; set; }

        public int MaxMainEngineSpeed { get; set; }

        public Guid MainEngineManufacturerId { get; set; }

        public MainEngineManufacturer? MainEngineManufacturer { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}