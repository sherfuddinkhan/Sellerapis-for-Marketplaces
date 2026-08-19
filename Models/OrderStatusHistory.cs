using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("OrderStatusHistory")]
    public class OrderStatusHistory
    {
        [Key]
        public int OrderStatusHistoryId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? ChangedOn { get; set; }
    }
}