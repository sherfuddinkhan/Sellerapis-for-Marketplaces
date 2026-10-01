using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ManifestPackages")]
    public class ManifestPackage
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManifestPackageId { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        // =========================================================
        // MANIFEST DETAILS
        // =========================================================

        [MaxLength(50)]
        public string ShippingManifestCode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ShippingPackageCode { get; set; } = string.Empty;
    }
}
