using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Identity.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
