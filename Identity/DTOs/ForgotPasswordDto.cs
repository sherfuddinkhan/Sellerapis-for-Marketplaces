using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Identity.DTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
