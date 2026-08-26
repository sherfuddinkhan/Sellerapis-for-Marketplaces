using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class CreateSellerCustomerRequest
    {
        // =========================================================
        // SELLER
        // =========================================================

        [Required]
        public int SellerId { get; set; }

        // =========================================================
        // CUSTOMER DETAILS
        // =========================================================

        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? TradeName { get; set; }

        [MaxLength(200)]
        public string? LegalName { get; set; }

        [MaxLength(200)]
        public string? ContactPerson { get; set; }

        // =========================================================
        // CONTACT DETAILS
        // =========================================================

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        // =========================================================
        // TAX DETAILS
        // =========================================================

        [MaxLength(15)]
        public string? GSTIN { get; set; }

        // =========================================================
        // ADDRESS DETAILS
        // =========================================================

        [MaxLength(200)]
        public string? AddressLine1 { get; set; }

        [MaxLength(200)]
        public string? AddressLine2 { get; set; }

        [MaxLength(200)]
        public string? BuildingName { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(10)]
        public string? StateCode { get; set; }

        [MaxLength(50)]
        public string? FloorNo { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        // =========================================================
        // FINANCIAL DETAILS
        // =========================================================

        public decimal? CreditLimit { get; set; }
    }
}