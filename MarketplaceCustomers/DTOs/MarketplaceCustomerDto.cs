public class MarketplaceCustomerDto
{
    public int id { get; set; }
    public int sellerId { get; set; }
    public int customerId { get; set; } // <-- ADD THIS IF MISSING
    public string? marketplaceCustomerId { get; set; }
    public string? marketplaceName { get; set; }
    public string companyName { get; set; } = null!;
    public string? gstin { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? stateCode { get; set; }
    public string? pincode { get; set; }
    public DateTime createdAt { get; set; }
}
