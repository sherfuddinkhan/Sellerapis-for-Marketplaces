namespace Marketplacesellerportal.DTOs
{
    public class InventoryAdjustmentDto
    {
        public int InventoryAdjustmentId { get; set; }

        public int ProductId { get; set; }

        public string SkuCode { get; set; } = "TN-WBH-001";

        public string AdjustmentType { get; set; } = "ADD";

        public decimal Quantity { get; set; } = 10;

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string BinCode { get; set; } = "BIN-A1";

        public string ShelfCode { get; set; } = "SHELF-01";

        public string Reason { get; set; } = "Stock Correction";
    }
}
