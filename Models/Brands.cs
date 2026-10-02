using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models;

[Table("Brands")]
public class Brand
{
    [Key]
    public int BrandId { get; set; }

    // ALL nvarchar in DB must be string? - NOT string
    public string? BrandCode { get; set; }
    public string? BrandName { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }

    public string? ChannelBrandId { get; set; }
    public string? ChannelCode { get; set; }

    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? BatchId { get; set; }
    public int? SellerId { get; set; }
    public bool? IsChannelSynced { get; set; }

    [NotMapped] public int? CustomerId { get; set; }

    [NotMapped]
    public bool IsCodeMatch => !string.IsNullOrWhiteSpace(BrandCode)
        && !string.IsNullOrWhiteSpace(BrandCode)
        && string.Equals(BrandCode, BrandCode, StringComparison.OrdinalIgnoreCase);

    [NotMapped] public int ProductCount { get; set; }
    [NotMapped] public int ModelCount { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<BrandModel> BrandModels { get; set; } = new List<BrandModel>();
}