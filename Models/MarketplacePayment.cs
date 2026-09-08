using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceSellerPortal.Models
{
    [Table("MarketplacePayments")]
    public class MarketplacePayment
    {
        [Key]
        public int MarketplacePaymentId { get; set; }

        public int MarketplaceOrderId { get; set; }

        [MaxLength(150)]
        public string? PaymentReference { get; set; }

        [MaxLength(100)]
        public string? PaymentStatus { get; set; }

        [MaxLength(100)]
        public string? PaymentMethod { get; set; }

        public decimal? GrossAmount { get; set; }

        public decimal? Commission { get; set; }

        public decimal? ShippingFee { get; set; }

        public decimal? Tax { get; set; }

        public decimal? NetAmount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
