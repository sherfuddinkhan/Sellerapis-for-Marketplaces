using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SalesInvoices.DTOs
{
    public class SalesInvoicePaymentRequest
    {
        // =========================================================
        // PAYMENT DETAILS
        // =========================================================

        public DateTime PaymentDate { get; set; }

        [MaxLength(100)]
        public string? PaymentMode { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(200)]
        public string? ReferenceNumber { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }
    }
}
