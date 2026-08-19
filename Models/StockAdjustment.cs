namespace Marketplacesellerportal.Models
{
    public class StockAdjustment
    {
        public int StockAdjustmentId { get; set; }
        
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public string AdjustmentType { get; set; } = string.Empty;
        public string? Reason { get; set; }
        public string? AdjustedBy { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
