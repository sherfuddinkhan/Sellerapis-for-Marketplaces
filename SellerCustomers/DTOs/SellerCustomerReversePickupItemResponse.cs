namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerReversePickupItemResponse
    {
        // =========================================================
        // PRIMARY / REFERENCE DETAILS
        // =========================================================

        public int ReversePickupItemId { get; set; }

        public int ReversePickupId { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        // =========================================================
        // ORDER ITEM DETAILS
        // =========================================================

        public string? SaleOrderItemCode { get; set; }

        // =========================================================
        // ITEM DETAILS
        // =========================================================

        public string? SkuCode { get; set; }

        public string? ItemSku { get; set; }

        // =========================================================
        // RETURN DETAILS
        // =========================================================

        public string? Reason { get; set; }

        // =========================================================
        // QUANTITY
        // =========================================================

        public decimal? Quantity { get; set; }

        // =========================================================
        // FACILITY / BIN
        // =========================================================

        public string? FacilityCode { get; set; }

        public string? BinCode { get; set; }

        // =========================================================
        // PRICE DETAILS
        // =========================================================

        public decimal TotalPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal Discount { get; set; }
    }
}