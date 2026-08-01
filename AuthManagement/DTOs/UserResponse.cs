namespace Marketplacesellerportal.AuthManagement.DTOs
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public int SellerId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}