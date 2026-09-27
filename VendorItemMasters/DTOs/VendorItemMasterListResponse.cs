using Marketplacesellerportal.VendorItemMasters.DTOs;

public class VendorItemMasterListResponse
{
    public bool Success { get; set; }
    public System.Collections.Generic.List<VendorItemMasterModel> Data { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
