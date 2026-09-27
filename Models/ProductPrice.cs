using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ProductPrices")]
    public class ProductPrice
    {
        [Key]
        public int ProductPriceId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        // =========================================================
        // PRICE
        // =========================================================
        [Required]
        [MaxLength(50)]
        public string PriceType { get; set; } = "OfferPrice";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "INR";

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        public bool IsActive { get; set; } = true;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Mrp { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? NotionalValueAmount { get; set; }

        [MaxLength(10)]
        public string? NotionalValueCurrency { get; set; }

        // =========================================================
        // UNIWARE / PRODUCT
        // =========================================================
        [MaxLength(100)]
        public string? SKU { get; set; }

        [MaxLength(100)]
        public string? Barcode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ChannelPrice { get; set; }

        [MaxLength(100)]
        public string? ChannelCode { get; set; }

        [MaxLength(100)]
        public string? UniwareChannelCode { get; set; }

        public bool? IsChannelCodeMatch { get; set; }

        // =========================================================
        // WAREHOUSE / FACILITY - THESE WERE MISSING
        // =========================================================
        public int? WarehouseId { get; set; }

        [MaxLength(100)]
        public string? WarehouseCode { get; set; }

        [MaxLength(100)]
        public string? FacilityCode { get; set; }

        [MaxLength(100)]
        public string? UniwareFacilityCode { get; set; }

        public bool? IsFacilityCodeMatch { get; set; }

        // =========================================================
        // BULK / BATCH
        // =========================================================
        [MaxLength(100)]
        public string? BatchId { get; set; }

        public bool? IsBulkUpload { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public decimal GMVPerOrder
        {
            get { return ChannelPrice ?? Price; }
        }

        // =========================================================
        // PRICE STATUS
        // =========================================================
        [NotMapped]
        public bool IsExpired
        {
            get
            {
                return EffectiveTo.HasValue &&
                       EffectiveTo.Value < DateTime.Now;
            }
        }

        [NotMapped]
        public bool IsPriceActiveForUniware
        {
            get
            {
                if (!IsActive) return false;
                if (EffectiveFrom > DateTime.Now) return false;
                if (EffectiveTo.HasValue && EffectiveTo.Value < DateTime.Now) return false;
                return true;
            }
        }

        // =========================================================
        // NAVIGATION
        // =========================================================
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        public Warehouse? Warehouse { get; set; }
    }
}