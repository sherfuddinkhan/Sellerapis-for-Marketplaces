using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("SupplierAddresses")]
    public class SupplierAddress
    {
        [Key]
        public int SupplierAddressId { get; set; }
        public int SupplierId { get; set; }
        [MaxLength(20)]
        public string AddressType { get; set; } // BILLING / SHIPPING
        [MaxLength(255)]
        public string AddressLine1 { get; set; }
        [MaxLength(255)]
        public string AddressLine2 { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; } = "IN";
        [MaxLength(5)]
        public string StateCode { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Pincode { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string Latitude { get; set; }
        [MaxLength(20)]
        public string Longitude { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
