namespace WebShop.Models.Identity
{
    public class IdentityUserProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Company { get; set; }
    }
}
