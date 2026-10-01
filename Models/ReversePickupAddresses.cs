using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ReversePickupAddresses", Schema = "dbo")]
    public class ReversePickupAddress
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        [Column("SellerId")]
        public int? SellerId { get; set; }

        [Column("CustomerId")]
        public int? CustomerId { get; set; }

        // =========================================================
        // REVERSE PICKUP
        // =========================================================

        [Column("reversePickupId")]
        public int? ReversePickupId { get; set; }

        // =========================================================
        // ADDRESS DETAILS
        // =========================================================

        [MaxLength(20)]
        [Column("addressType")]
        public string? AddressType { get; set; }

        [MaxLength(255)]
        [Column("addressLine1")]
        public string? AddressLine1 { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(10)]
        [Column("pincode")]
        public string? Pincode { get; set; }

        // =========================================================
        // CONTACT DETAILS
        // =========================================================

        [MaxLength(20)]
        [Column("phone")]
        public string? Phone { get; set; }
    }
}