namespace ShipInfo.DAL
{
    public class ShipPropulsorType
    {
        public Guid Id { get; set; }

        public string? ShipPropulsorTypeName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}