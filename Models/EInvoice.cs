using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("EInvoices")]
    public class EInvoice
    {
        [Key]
        [Column("EInvoiceId")]
        public int EInvoiceId { get; set; }

        [Column("SellerId")]
        public int SellerId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("SalesInvoiceId")]
        public int SalesInvoiceId { get; set; }

        [Column("InvoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Column("IRN")]
        public string IRN { get; set; } = string.Empty;

        [Column("AckNo")]
        public string AckNo { get; set; } = string.Empty;

        [Column("AckDate")]
        public DateTime? AckDate { get; set; }

        [Column("Status")]
        public string Status { get; set; } = string.Empty;

        // ==============================
        // SIGNED E-INVOICE DATA
        // ==============================

        [Column("SignedInvoice")]
        public string? SignedInvoice { get; set; }

        [Column("QrCode")]
        public string? SignedQrCode { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }
    }
}