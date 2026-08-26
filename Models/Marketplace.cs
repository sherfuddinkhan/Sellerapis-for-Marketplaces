using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Models
{
    public class Marketplace
    {
        [Key]
        public int MarketplaceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string MarketplaceName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string MarketplaceCode { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
