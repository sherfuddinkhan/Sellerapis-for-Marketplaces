namespace Marketplacesellerportal.ReversePickup.DTOs
{
    public class ReversePickupStatisticsResponse 
   { 
        public bool Success { get; set; } 
        public ReversePickupStatistics Data { get; set; } = new(); }
}
