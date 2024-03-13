namespace ShipInfo.DAL
{
    public class Owner : Base
    {
        public Guid Id { get; set; }

        public string? OwnerName { get; set; }

        public string? OwnerAddress { get; set; }

        public string? OwnerEmail { get; set; }

        public string? OwnerPhone { get; set; }

        public ICollection<Ship>? Ships { get; set; }
    }
}