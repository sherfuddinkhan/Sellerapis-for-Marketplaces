using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Sellers.DTOs
{
    public class RegisterSellerRequest
    {
        // ==============================
        // SELLER DETAILS
        // ==============================

        [Required]
        [MaxLength(200)]
        public string SellerName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string TradeName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string LegalName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactPerson { get; set; } = string.Empty;

        // ==============================
        // CONTACT DETAILS
        // ==============================

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        // ==============================
        // TAX DETAILS
        // ==============================

        [MaxLength(15)]
        public string GSTIN { get; set; } = string.Empty;

        // ==============================
        // ADDRESS DETAILS
        // ==============================

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(200)]
        public string BuildingName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string State { get; set; } = string.Empty;

        [MaxLength(10)]
        public string StateCode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string FloorNo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}