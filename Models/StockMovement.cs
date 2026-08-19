using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("StockMovement")]
    public class StockMovement
    {
        public int StockMovementId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public string? MovementType { get; set; }

        public decimal? Quantity { get; set; }

        public string? ReferenceTable { get; set; }

        public int? ReferenceId { get; set; }

        public DateTime? MovementDate { get; set; }

        public string? Remarks { get; set; }
    }
}