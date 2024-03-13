namespace ShipInfo.DAL
{
    public class ShipBuilder : Base
    {
        public Guid Id { get; set; }

        public string? ShipBuilderName { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}