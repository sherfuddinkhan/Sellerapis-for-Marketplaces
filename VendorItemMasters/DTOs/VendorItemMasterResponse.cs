using Marketplacesellerportal.VendorItemMasters.DTOs;

public class VendorItemMasterResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public VendorItemMasterModel? Data { get; set; }
}