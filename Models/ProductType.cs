using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ProductTypes")]
    public class ProductType
    {
        [Key] public int ProductTypeId { get; set; }
        public int SellerId { get; set; } = 6;
        public int CustomerId { get; set; } = 3;

        [Required][MaxLength(200)] public string ProductTypeName { get; set; } = null!;
        [MaxLength(100)] public string? ProductTypeCode { get; set; }


        public int? CategoryId { get; set; }
        [MaxLength(500)] public string? Description { get; set; }

        // GST - Mandatory for Topaz
        [MaxLength(50)] public string? HSNCode { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? GSTPercentage { get; set; } = 18;

        public bool IsActive { get; set; } = true;
        public bool? IsSystemDefined { get; set; } = false;
        public int? DisplayOrder { get; set; } = 0;
        [MaxLength(1000)] public string? ImageUrl { get; set; }
        [MaxLength(1000)] public string? IconUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";

        // Calculated
        [NotMapped] public string? CategoryName => Category?.CategoryName;

        // Navigation
        [ForeignKey(nameof(CategoryId))] public Category? Category { get; set; }
    }
}