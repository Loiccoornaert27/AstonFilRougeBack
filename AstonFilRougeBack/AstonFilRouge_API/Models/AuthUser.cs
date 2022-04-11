using System.ComponentModel.DataAnnotations;

namespace AstonFilRouge_API.Models
{
    public class AuthUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
