public class SellerCustomerBrandResponse
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
