namespace ShipInfo.DAL
{
    public class AuxiliaryEngineManufacturer : Base
    {
        public Guid Id { get; set; }

        public string? AuxiliaryEngineManufacturerName { get; set; }

        public ICollection<AuxiliaryEngine>? AuxiliaryEngines { get; set; }

    }
}