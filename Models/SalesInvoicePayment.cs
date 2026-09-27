using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Marketplacesellerportal.Models
{
    public class SalesInvoicePayment
    {
        // =====================================================
        // PRIMARY KEY
        // =====================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesInvoicePaymentId { get; set; }


        // =====================================================
        // INVOICE RELATIONSHIP
        // =====================================================

        public int SalesInvoiceId { get; set; }


        // =====================================================
        // PAYMENT DETAILS
        // =====================================================

        public DateTime PaymentDate { get; set; }

        public string? PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Remarks { get; set; }


        // =====================================================
        // NAVIGATION PROPERTY
        // =====================================================
        [JsonIgnore]
        public SalesInvoice? SalesInvoice { get; set; }
    }
}
