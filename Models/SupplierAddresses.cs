using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("supplierAddresses")] // your real table is lowercase
    public class SupplierAddress
    {
        [Key]
        [Column("supplierAddressId")]
        public int SupplierAddressId { get; set; }

        [Column("supplierId")]
        public int SupplierId { get; set; }

        [Column("addressType")]
        public string? AddressType { get; set; }

        [Column("addressLine1")]
        public string? AddressLine1 { get; set; }

        [Column("addressLine2")]
        public string? AddressLine2 { get; set; }

        [Column("countryCode")]
        public string? CountryCode { get; set; }

        [Column("stateCode")]
        public string? StateCode { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("pincode")]
        public string? Pincode { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("latitude")]
        public string? Latitude { get; set; }

        [Column("longitude")]
        public string? Longitude { get; set; }

        [Column("SellerId")]
        public int SellerId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
    }
}