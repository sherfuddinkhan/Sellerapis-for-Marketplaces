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
    }
}
