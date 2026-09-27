public class ReversePickupListRequest
{
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public string? ReversePickupNo { get; set; }
    public string? SaleOrderCode { get; set; }
    public string? ItemSkuCode { get; set; }
    public string? Status { get; set; }
    public string? FacilityCode { get; set; }
    public string? SearchTerm { get; set; }
    public System.DateTime? FromDate { get; set; }
    public System.DateTime? ToDate { get; set; }
    public string SortOrder { get; set; } = "DESC";
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public void Normalize() { if (PageNumber < 1) PageNumber = 1; if (PageSize < 1) PageSize = 20; }
}