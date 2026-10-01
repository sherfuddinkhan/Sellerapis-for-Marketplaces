namespace Marketplacesellerportal.InventoryAdjustments.DTOs
{
    public class CreateInventoryAdjustmentDto
    {
        public int ProductId { get; set; }

        public string SkuCode { get; set; } = "TN-WBH-001";

        public string AdjustmentType { get; set; } = "ADD";

        public decimal Quantity { get; set; } = 10;

        public string Reason { get; set; } = "Stock Correction";

        public string FacilityCode { get; set; } = "TN-WH-01";
    }
}
