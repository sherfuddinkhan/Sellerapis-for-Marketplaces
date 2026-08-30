using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("BrandModels")]
    public class BrandModel
    {
        [Key]
        public int BrandModelId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ModelName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
    }
}