using System.ComponentModel.DataAnnotations;

namespace ShipInfo.DOMAIN
{
    public class UserLogginRequest
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
