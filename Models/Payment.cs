using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public string? PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public string? PaymentStatus { get; set; }

        public string? TransactionId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
    }
}
