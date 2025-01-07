namespace ShipInfo.Domain.Entities
{
    public class AuxiliaryEngine
    {
        public Guid Id { get; set; }

        public string? AuxiliaryEngineType { get; set; }

        public int MaxAuxiliaryEnginePower { get; set; }

        public int MaxAuxiliaryEngineSpeed { get; set; }

        public Guid AuxiliaryEngineManufacturerId { get; set; }

        public AuxiliaryEngineManufacturer? AuxiliaryEngineManufacturer { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}