using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Form
{
    public class LoginForm
    {
        public string? ReturnUrl { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public bool KeepMeLoggedIn { get; set; }
    }
}
