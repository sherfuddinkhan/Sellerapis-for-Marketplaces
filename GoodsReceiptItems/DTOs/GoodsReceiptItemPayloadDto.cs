namespace Marketplacesellerportal.GoodsReceiptItems.DTOs
{
    public class GoodsReceiptItemPayloadDto
    {
        public string SkuCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string BatchCode { get; set; } = string.Empty;
        public string VendorCode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public List<GoodsReceiptItemDetailDto> ItemDetails { get; set; } = new();
    }

    public class GoodsReceiptItemDetailDto
    {
        public string Code { get; set; } = string.Empty;
    }
}
