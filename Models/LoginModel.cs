using System.ComponentModel.DataAnnotations;

namespace SafeVault.Models
{
    // Model for user login input
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
