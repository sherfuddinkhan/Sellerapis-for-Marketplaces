namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerGatepassResponse
    {
        public int GatepassId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string FacilityCode { get; set; } = string.Empty;
        public string? Facility { get; set; }
        public string? GatepassCode { get; set; }
        public string? ItemSkuCode { get; set; }
        public int? Quantity { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
