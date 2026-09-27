using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class SalesInvoiceAdditionalCharge
    {
        // =====================================================
        // PRIMARY KEY
        // =====================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesInvoiceAdditionalChargeId { get; set; }


        // =====================================================
        // INVOICE RELATIONSHIP
        // =====================================================

        public int SalesInvoiceId { get; set; }


        // =====================================================
        // CHARGE DETAILS
        // =====================================================

        [Required]
        public string ChargeName { get; set; } = string.Empty;

        public string? ChargeType { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Remarks { get; set; }


        // =====================================================
        // NAVIGATION PROPERTY
        // =====================================================

        public SalesInvoice? SalesInvoice { get; set; }
    }
}
