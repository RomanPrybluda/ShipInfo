namespace ShipInfo.Domain.Entities
{
    public class AuxiliaryEngineManufacturer
    {
        public Guid Id { get; set; }

        public string? AuxiliaryEngineManufacturerName { get; set; }

        public ICollection<AuxiliaryEngine>? AuxiliaryEngines { get; set; }

    }
}