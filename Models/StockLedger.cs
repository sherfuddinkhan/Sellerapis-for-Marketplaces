using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("StockLedger")]
    public class StockLedger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockLedgerId { get; set; }

        // All FKs made int? to handle NULL in DB - this fixes SqlNullValueException
        public int? SellerId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? WarehouseId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? TransactionType { get; set; } = string.Empty;

        [Column(TypeName = "VARCHAR(100)")]
        public string? ReferenceNumber { get; set; }

        // Was decimal - now decimal? for NULL
        public decimal? Quantity { get; set; }
        public decimal? BalanceQuantity { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        public string? Remarks { get; set; }

        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}