using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("StockLedger")]
    public class StockLedger
    {
        public int StockLedgerId { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public string? ReferenceNumber { get; set; }

        public decimal Quantity { get; set; }

        public decimal BalanceQuantity { get; set; }

        public string? Remarks { get; set; }

        public DateTime? TransactionDate { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}