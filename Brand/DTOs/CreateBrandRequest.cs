using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Brand.DTOs
{
    public class CreateBrandRequest
    {
        [Required]
   

        public List<int> ProductIds { get; set; } = new();

        [Required]
        [MaxLength(200)]
        public string BrandName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
