namespace ShipInfo.Domain.Entities
{
    public class ShipType
    {
        public Guid Id { get; set; }

        public string? ShipTypeName { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}