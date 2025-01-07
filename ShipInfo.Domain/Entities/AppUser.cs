namespace ShipInfo.Domain.Entities
{
    public class AppUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
