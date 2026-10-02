namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPriceResponse
    {
        public int ProductPriceId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string PriceType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? Mrp { get; set; } = null;
        public decimal? NotionalValueAmount { get; set; } = null;
        public string? NotionalValueCurrency { get; set; } = "INR";
        public string? Sku { get; set; }
        public string? Barcode { get; set; }
        public string? WarehouseCode { get; set; }
        public string? FacilityCode { get; set; }
        public string? ChannelCode { get; set; }
        public decimal? ChannelPrice { get; set; }
        public string? BatchId { get; set; }
        public int? WarehouseId { get; set; }
        public bool? IsFacilityCodeMatch { get; set; }
        public bool? IsChannelCodeMatch { get; set; }

    }
}