using System.ComponentModel.DataAnnotations;

namespace ShipInfo.DOMAIN
{
    public class UserRegisterRequest
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Age must be a positive number.")]
        public int? Age { get; set; }


    }
}
