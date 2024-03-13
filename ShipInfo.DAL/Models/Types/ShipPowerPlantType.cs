namespace ShipInfo.DAL
{
    public class ShipPowerPlantType : Base
    {
        public Guid Id { get; set; }

        public string? ShipPowerPlantTypeName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}