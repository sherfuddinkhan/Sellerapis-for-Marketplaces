namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSellerResponse
    {
        public int SellerId { get; set; }

        public string SellerName { get; set; } = string.Empty;

        public string? SellerCode { get; set; }

        // ==============================
        // BUSINESS / LEGAL DETAILS
        // ==============================

        public string? TradeName { get; set; }

        public string? LegalName { get; set; }

        public string? ContactPerson { get; set; }

        public string? GSTIN { get; set; }

        // ==============================
        // CONTACT DETAILS
        // ==============================

        public string? Email { get; set; }

        public string? Phone { get; set; }

        // ==============================
        // ADDRESS DETAILS
        // ==============================

        public string? Address { get; set; }

        public string? BuildingName { get; set; }

        public string? Location { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? StateCode { get; set; }

        public string? FloorNo { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        // ==============================
        // STATUS / AUDIT
        // ==============================

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}