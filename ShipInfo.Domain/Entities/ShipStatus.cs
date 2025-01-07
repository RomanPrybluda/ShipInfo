namespace ShipInfo.Domain.Entities
{
    public class ShipStatus
    {
        public Guid Id { get; set; }

        public string? StatusName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}