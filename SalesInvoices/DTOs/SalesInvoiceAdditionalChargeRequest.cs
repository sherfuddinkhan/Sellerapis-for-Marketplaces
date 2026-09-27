using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SalesInvoices.DTOs
{
    public class SalesInvoiceAdditionalChargeRequest
    {
        // =========================================================
        // CHARGE DETAILS
        // =========================================================

        [Required]
        [MaxLength(200)]
        public string ChargeName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ChargeType { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }
    }
}
