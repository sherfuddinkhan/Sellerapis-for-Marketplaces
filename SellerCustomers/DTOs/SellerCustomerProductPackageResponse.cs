public class SellerCustomerProductPackageResponse
{
    public int PackageId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Breadth { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string? Description { get; set; }
    public bool IsFragile { get; set; }

    // NEW - Respective to ProductPackages table
    public string? PackageType { get; set; } = "DEFAULT";
    public bool IsHazardous { get; set; } = false;
    public int DefectCount { get; set; } = 0;
}
