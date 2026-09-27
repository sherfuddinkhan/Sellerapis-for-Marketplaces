namespace Marketplacesellerportal.ReversePickup.DTOs
{
    public class ReversePickupStatistics
    { 
        public int TotalCount { get; set; } 
        public Dictionary<string, int> ByStatus { get; set; } = new(); 
    }
}
