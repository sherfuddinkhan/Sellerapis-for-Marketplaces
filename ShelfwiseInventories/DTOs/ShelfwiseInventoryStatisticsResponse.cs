namespace Marketplacesellerportal.ShelfwiseInventory.DTOs
{
    public class ShelfwiseInventoryStatisticsResponse
    {
        public bool Success { get; set; }
        public ShelfwiseInventoryStatistics Data { get; set; } = new();
    }
}
