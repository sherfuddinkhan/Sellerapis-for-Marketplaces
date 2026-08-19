using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        public int SellerId { get; set; }

        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
        public string PurchaseOrderNumber { get; set; } = string.Empty;

        public DateTime? OrderDate { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
