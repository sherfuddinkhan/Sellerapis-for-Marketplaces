using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("SaleOrderAddresses", Schema = "dbo")]
    public class SaleOrderAddress
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        [MaxLength(50)]
        [Column("AddressId")]
        public string AddressId { get; set; } = string.Empty;


        // =========================================================
        // SALES ORDER
        // =========================================================

        [Column("SalesOrderId")]
        public int? SalesOrderId { get; set; }


        // =========================================================
        // CUSTOMER / RECIPIENT
        // =========================================================

        [MaxLength(100)]
        [Column("Name")]
        public string? Name { get; set; }


        // =========================================================
        // ADDRESS
        // =========================================================

        [MaxLength(255)]
        [Column("AddressLine1")]
        public string? AddressLine1 { get; set; }

        [MaxLength(255)]
        [Column("AddressLine2")]
        public string? AddressLine2 { get; set; }

        [MaxLength(100)]
        [Column("City")]
        public string? City { get; set; }

        [MaxLength(100)]
        [Column("State")]
        public string? State { get; set; }

        [MaxLength(10)]
        [Column("StateCode")]
        public string? StateCode { get; set; }

        [MaxLength(10)]
        [Column("CountryCode")]
        public string? CountryCode { get; set; }

        [MaxLength(20)]
        [Column("Pincode")]
        public string? Pincode { get; set; }


        // =========================================================
        // CONTACT
        // =========================================================

        [MaxLength(20)]
        [Column("Phone")]
        public string? Phone { get; set; }

        [MaxLength(100)]
        [Column("Email")]
        public string? Email { get; set; }


        // =========================================================
        // GEO LOCATION
        // =========================================================

        [MaxLength(100)]
        [Column("Latitude")]
        public string? Latitude { get; set; }

        [MaxLength(100)]
        [Column("Longitude")]
        public string? Longitude { get; set; }
    }
}