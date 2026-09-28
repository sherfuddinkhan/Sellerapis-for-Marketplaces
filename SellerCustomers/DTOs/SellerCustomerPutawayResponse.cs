namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPutawayResponse
    {
        public int PutawayId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string FacilityCode { get; set; } = string.Empty;
        public string ShelfCode { get; set; } = string.Empty;
        public string? PutawayCode { get; set; }
        public string ItemTypeSkuCode { get; set; } = "";
        public int? PutawayQuantity { get; set; }
        public string? BatchCode { get; set; }
        public string? InventoryType { get; set; }
        public string? PutawayType { get; set; }
        public string? StatusCode { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
