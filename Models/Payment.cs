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

        public decimal? Amount { get; set; }

        public string? PaymentStatus { get; set; }

        public string? TransactionId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }


        // =========================================================
        // BANK DETAILS
        // =========================================================

        public string? BankName { get; set; }

        public string? AccountHolderName { get; set; }

        public string? AccountNumber { get; set; }

        public string? IFSCCode { get; set; }

        public string? BranchName { get; set; }


        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        public string? GatewayName { get; set; }

        public string? GatewayMerchantId { get; set; }

        public string? GatewayKey { get; set; }

        public string? GatewaySecret { get; set; }

        public bool GatewayEnabled { get; set; }


        // =========================================================
        // UPI
        // =========================================================

        public string? UPIId { get; set; }

        public string? UPIName { get; set; }

        public bool UPIEnabled { get; set; }


        // =========================================================
        // AUDIT
        // =========================================================

        public DateTime? UpdatedDate { get; set; }
    }
}