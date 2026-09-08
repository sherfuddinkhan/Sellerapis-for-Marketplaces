using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceSellerPortal.Models
{
    [Table("MarketplaceOrderAddresses")]
    public class MarketplaceOrderAddress
    {
        [Key]
        public int MarketplaceOrderAddressId { get; set; }

        public int MarketplaceOrderId { get; set; }

        [MaxLength(30)]
        public string? AddressType { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? Company { get; set; }

        [MaxLength(250)]
        public string? AddressLine1 { get; set; }

        [MaxLength(250)]
        public string? AddressLine2 { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [MaxLength(30)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
