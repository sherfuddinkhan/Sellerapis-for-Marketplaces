using Marketplacesellerportal.ReversePickups.DTOs;

public class ReversePickupListResponse
{
    public bool Success { get; set; }
    public System.Collections.Generic.List<ReversePickupModel> Data { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
