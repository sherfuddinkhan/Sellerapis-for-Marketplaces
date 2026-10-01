namespace Marketplacesellerportal.SellerCustomer.DTOs
{
    public class SellerCustomerInventoryAdjustmentResponse
    {
        public int InventoryAdjustmentId { get; set; }
        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public int? ProductId { get; set; }

        public string? SkuCode { get; set; }

        public string? AdjustmentType { get; set; }

        public decimal? Quantity { get; set; }

        public string? FacilityCode { get; set; }

        public string? BinCode { get; set; }

        public string? ShelfCode { get; set; }

        public string? Reason { get; set; }
    }
}
