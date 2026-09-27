public class VendorItemMasterListRequest
{
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public string? SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public void Normalize() { if (PageNumber < 1) PageNumber = 1; if (PageSize < 1) PageSize = 20; }
}