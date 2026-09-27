namespace Marketplacesellerportal.ReversePickups.DTOs
{
    public class ReversePickupModel
    {
        public int ReversePickupId { get; set; }
        public int Id => ReversePickupId; // alias for controller compatibility
        public string ReversePickupNo { get; set; } = "";
        public string SaleOrderCode { get; set; } = "";
        public string SaleOrderItemCode { get; set; } = "";
        public string ItemSkuCode { get; set; } = "";
        public string TrackingNo { get; set; } = "";
        public string ReturnReason { get; set; } = "";
        public string QCComment { get; set; } = "";
        public string ReversePickupStatus { get; set; } = "";
        public string CourierProviderName { get; set; } = "";
        public string FacilityCode { get; set; } = "";
        public string ChannelName { get; set; } = "";
        public string PutawayCode { get; set; } = "";
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime? UpdatedDate { get; set; }
    }
}