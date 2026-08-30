using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.BrandModel.DTOs
{
    public class BrandModelDto
    {
        public int BrandModelId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ModelName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
