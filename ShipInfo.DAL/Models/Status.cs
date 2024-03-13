namespace ShipInfo.DAL
{
    public class Status : Base
    {
        public Guid Id { get; set; }

        public string? StatusName { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}