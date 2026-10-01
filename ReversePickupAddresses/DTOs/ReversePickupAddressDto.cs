namespace Marketplacesellerportal.DTOs
{
    public class ReversePickupAddressDto
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        public int ReversePickupAddressId { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        // =========================================================
        // REVERSE PICKUP
        // =========================================================

        public int? ReversePickupId { get; set; }

        // =========================================================
        // ADDRESS DETAILS
        // =========================================================

        public string? AddressType { get; set; } = "PICKUP";

        public string? City { get; set; } = "";

        public string? Pincode { get; set; } = "";

        public string? AddressLine1 { get; set; } = "";

        // =========================================================
        // CONTACT
        // =========================================================

        public string? Phone { get; set; }
    }
}
