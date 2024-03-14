namespace ShipInfo.DAL
{
    public class ShipFlag
    {
        public Guid Id { get; set; }

        public string? ShipFlagName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}