namespace ShipInfo.Domain.Entities
{
    public class ShipBuilder
    {
        public Guid Id { get; set; }

        public string? ShipBuilderName { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}