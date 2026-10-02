using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Required][MaxLength(200)] public string CategoryName { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
        [MaxLength(500)] public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        // Uniware - Mandatory
        [MaxLength(100)] public string? CategoryCode { get; set; }
        [MaxLength(1000)] public string? CategoryPath { get; set; }
        public int? CategoryLevel { get; set; }
        public int? DisplayOrder { get; set; }
        [MaxLength(1000)] public string? ImageUrl { get; set; }
        [MaxLength(100)] public string? BatchId { get; set; }
        public bool? IsBulkUpload { get; set; } = false;
        [MaxLength(100)] public string? ChannelCode { get; set; } = "CUSTOM";
        public int? SellerId { get; set; } = 6;
        public int? CustomerId { get; set; } = 3;

        // FIXED: You had CreatedBy missing for mapping
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";
        [MaxLength(100)] public string? UpdatedBy { get; set; }

        // Calculated
        [NotMapped] public bool IsCodeMatch => !string.IsNullOrWhiteSpace(CategoryCode) && !string.IsNullOrWhiteSpace(CategoryCode) && string.Equals(CategoryCode,CategoryCode, StringComparison.OrdinalIgnoreCase);
        [NotMapped] public int ProductCount { get; set; }
        [NotMapped] public int Level => CategoryLevel ?? (ParentCategoryId == null ? 1 : 2);
        [NotMapped] public string? ParentCategoryName => ParentCategory?.CategoryName;

        // Navigation
        [ForeignKey(nameof(ParentCategoryId))] public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // SEO + GST - Missing in your Model, causing 7 errors
        [MaxLength(1000)] public string? BannerUrl { get; set; }
        [MaxLength(1000)] public string? IconUrl { get; set; }
        [MaxLength(200)] public string? MetaTitle { get; set; }
        [MaxLength(500)] public string? MetaDescription { get; set; }
        public bool? IsSystemDefined { get; set; } = false;
        [MaxLength(50)] public string? HSNCode { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? GSTPercentage { get; set; }
    }
}