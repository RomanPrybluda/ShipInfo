namespace ShipInfo.DAL
{
    public class ShipType
    {
        public Guid Id { get; set; }

        public string? ShipTypeName { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}