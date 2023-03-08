using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Form
{
    public class RegisterForm
    {
        public string ReturnUrl { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        public bool TermsAndAggreements { get; set; }
    }
}
