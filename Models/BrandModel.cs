using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("BrandModels")]
    public class BrandModel
    {
        [Key]
        public int BrandModelId { get; set; }

         public string BrandCode { get; set; }

         public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [MaxLength(2000)] public string? Specifications { get; set; }
        [MaxLength(500)] public string? ImageUrl { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        // REAL COLUMNS IN dbo.BrandModels
        public string? Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        // === ALL CODE-ONLY PROPERTIES - NOT IN dbo.BrandModels ===
        [NotMapped] public string? ModelCode { get; set; }
        [NotMapped] public string? UniwareModelCode { get; set; }
        [NotMapped] public string? Barcode { get; set; }
        [NotMapped] public string? BarcodeType { get; set; }
        [NotMapped] public string? BarcodeImageUrl { get; set; }
        [NotMapped] public bool? IsBarcodeVerified { get; set; }
        [NotMapped] public DateTime? BarcodeVerifiedDate { get; set; }
        [NotMapped] public string? ChannelModelId { get; set; }
        [NotMapped] public string? ChannelCode { get; set; }
        [NotMapped] public string? UniwareChannelCode { get; set; }
        [NotMapped] public string? ChannelProductId { get; set; }
        [NotMapped] public string? BatchId { get; set; }
        [NotMapped] public int? SellerId { get; set; }
        [NotMapped] public int? CustomerId { get; set; }
        [NotMapped] public int? ProductId { get; set; }
        [NotMapped] public string? SKU { get; set; }
        [NotMapped] public bool? IsCodeMatch { get; set; }
        [NotMapped] public bool? IsChannelCodeMatch { get; set; }
        [NotMapped] public bool? IsChannelSynced { get; set; }
        [NotMapped] public DateTime? LastChannelSyncDate { get; set; }
        [NotMapped] public string? ChannelSyncStatus { get; set; }
        [NotMapped] public string? SpecificationsJson { get; set; }
        [NotMapped] public Product? Product { get; set; }
    }
}