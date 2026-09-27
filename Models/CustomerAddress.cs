using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("CustomerAddresses")]
    public class CustomerAddress
    {
        [Key]
        public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressType { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool? IsDefault { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
