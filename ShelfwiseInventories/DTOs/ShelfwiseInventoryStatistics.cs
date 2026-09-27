namespace Marketplacesellerportal.ShelfwiseInventory.DTOs
{
    public class ShelfwiseInventoryStatistics
    {
        public int TotalCount { get; set; }
        public int TotalQuantity { get; set; }
        public Dictionary<string, int> ByFacility { get; set; } = new();
        public Dictionary<string, int> ByInventoryType { get; set; } = new();
    }
}
