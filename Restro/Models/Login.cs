using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

