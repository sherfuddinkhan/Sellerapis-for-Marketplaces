using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ShippingManifests")]
    public class ShippingManifest
    {
        [Key]
        [MaxLength(50)]
        public string ShippingManifestCode { get; set; }
        [MaxLength(50)]
        public string Channel { get; set; } = "CUSTOM";
        [MaxLength(50)]
        public string ShippingProviderCode { get; set; }
        [MaxLength(100)]
        public string ShippingProviderName { get; set; }
        [MaxLength(50)]
        public string ShippingMethodCode { get; set; }
        public string Comments { get; set; }
        [MaxLength(20)]
        public string Status { get; set; } = "CREATED";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool ThirdPartyShipping { get; set; } = false;
        // === FIX FOR YOUR ERROR ===
        [NotMapped]
        public int ShippingManifestId => ShippingManifestCode.GetHashCode();
        [NotMapped]
        public string ManifestNumber => ShippingManifestCode;
        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        // === MISSING - ADD THESE (from DB) ===
        [MaxLength(50)]
        public string? CourierCode { get; set; }

        [MaxLength(100)]
        public string? TrackingNumber { get; set; }

        [MaxLength(20)]
        public string? ManifestType { get; set; } = "OUTBOUND";
    }
}
