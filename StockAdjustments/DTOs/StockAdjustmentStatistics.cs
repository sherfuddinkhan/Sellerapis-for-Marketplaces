namespace Marketplacesellerportal.StockAdjustments.DTOs
{
    public class StockAdjustmentStatistics
    {
        public int TotalAdjustments { get; set; }

        public int PositiveAdjustments { get; set; }

        public int NegativeAdjustments { get; set; }

        public decimal TotalQuantityAdjusted { get; set; }

        public decimal AverageQuantityAdjusted { get; set; }
    }
}
