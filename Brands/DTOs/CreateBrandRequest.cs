using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Brands.DTOs
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
        public string BrandCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int? SellerId { get; set; }
    }
}
