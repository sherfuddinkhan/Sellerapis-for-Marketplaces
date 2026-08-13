namespace Marketplacesellerportal.AuthManagement.DTOs
{
    public class RegisterRequest
    {
        public int SellerId { get; set; }

        public int? CustomerId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Password { get; set; } = string.Empty;

        public string? Mobile { get; set; }

        public string Role { get; set; } = string.Empty;
    }
}
