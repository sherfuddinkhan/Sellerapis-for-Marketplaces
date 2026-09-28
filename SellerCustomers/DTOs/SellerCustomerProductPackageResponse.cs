using System.ComponentModel.DataAnnotations;

public class ProductPackageResponse
{
    public string Name { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Breadth { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string? Description { get; set; }
    public bool IsFragile { get; set; }
    public string? PackageType { get; set; } = "DEFAULT";
    public bool IsHazardous { get; set; } = false;
    public int DefectCount { get; set; } = 0;
    public string? DefectDetails { get; set; }
    public int? PackageXID { get; set; }
    public bool? IsPrimary { get; set; } = true;
    public int? AddressLabelXID { get; set; }
    [MaxLength(100)] public string? FSSAILicense { get; set; }
}
