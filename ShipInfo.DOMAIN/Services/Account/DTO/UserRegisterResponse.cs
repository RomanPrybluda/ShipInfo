namespace ShipInfo.Domain
{
    public class UserRegisterResponse
    {
        public string UserName { get; internal set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public string Id { get; internal set; }

    }
}
