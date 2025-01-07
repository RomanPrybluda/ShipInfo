namespace ShipInfo.Domain.Entities
{
    public class ShipPowerPlantType
    {
        public Guid Id { get; set; }

        public string? ShipPowerPlantTypeName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}