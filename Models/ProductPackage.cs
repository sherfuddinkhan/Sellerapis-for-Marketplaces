using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ProductPackages")] // or your actual table name
    public class ProductPackage
    {
        [Key] // ADD THIS - THIS FIXES YOUR ERROR IN SCREENSHOT
        public int PackageId { get; set; }

        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;

        public decimal? Length { get; set; }
        public decimal? Breadth { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

        public string? Description { get; set; }
        public bool? IsFragile { get; set; } = false;
        public string? FlipkartPackageId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public string? PackageType { get; set; } = "DEFAULT";
        public bool? IsHazardous { get; set; } = false;
        public int? DefectCount { get; set; } = 0;
        public string? DefectDetails { get; set; }
    }
}