using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("StockAdjustments")]
    public class StockAdjustment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockAdjustmentId { get; set; }

        // All FKs nullable to fix SqlNullValueException
        public int? CustomerId { get; set; }
        public int? SellerId { get; set; }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }

        public decimal? Quantity { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? AdjustmentType { get; set; } = string.Empty;

        [Column(TypeName = "VARCHAR(500)")]
        public string? Reason { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? AdjustedBy { get; set; }

        public DateTime? AdjustmentDate { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}