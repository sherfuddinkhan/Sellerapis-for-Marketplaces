using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("StockTransfers")]
    public class StockTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockTransferId { get; set; }

        // Made nullable to handle NULL in DB
        public int? SellerId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public int? FromWarehouseId { get; set; }
        public int? ToWarehouseId { get; set; }

        // Was decimal - now decimal?
        public decimal? Quantity { get; set; }

        public DateTime? TransferDate { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Status { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}