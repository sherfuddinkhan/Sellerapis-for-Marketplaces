namespace Marketplacesellerportal.VendorItemMaster.DTOs
{
    public class VendorItemMasterStatisticsResponse 
    { 
        public bool Success { get; set; } 
        public VendorItemMasterStatistics Data { get; set; } = new(); }
}
