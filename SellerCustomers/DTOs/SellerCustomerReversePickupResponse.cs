namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerReversePickupResponse
    {
        public int ReversePickupId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string? ReversePickupNo { get; set; }
        public string? FacilityCode { get; set; }
        public string? ItemSkuCode { get; set; }
        public string? ReversePickupStatus { get; set; }
        public string SaleOrderCode { get; set; } = ""; // <-- ADD THIS
        public string SaleOrderItemCode { get; set; } = "";
        public string? ReturnReason { get; set; }
        public string? ChannelName { get; set; }
        public string? Status { get; set; }
        public string? TrackingNo { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
