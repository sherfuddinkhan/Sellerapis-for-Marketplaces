using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Sellers.DTOs
{
    public class RegisterSellerRequest
    {
        [Required]
        [MaxLength(200)]
        public string SellerName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(15)]
        public string GSTIN { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string State { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}