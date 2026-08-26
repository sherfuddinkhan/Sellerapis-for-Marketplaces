using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class SalesInvoice
    {
        // =========================================================
        // PRIMARY / REFERENCE DETAILS
        // =========================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesInvoiceId { get; set; }

        public int SalesOrderId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        // =========================================================
        // INVOICE DETAILS
        // =========================================================

        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }

        public string? InvoiceScenario { get; set; }

        public string? Category { get; set; }

        public string? TransactionType { get; set; }

        // =========================================================
        // GST / TAX DETAILS
        // =========================================================

        public string? UserGSTIN { get; set; }

        public string? DocumentType { get; set; }

        public string? SupplyType { get; set; }

        public string? PlaceOfSupply { get; set; }

        public string? FinancialYear { get; set; }

        public bool ReverseCharge { get; set; }

        // =========================================================
        // ID / REFERENCE DETAILS
        // =========================================================

        public string? Id { get; set; }

        public string? RefId { get; set; }

        // =========================================================
        // AMOUNT DETAILS
        // =========================================================

        public decimal SubTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal BalanceAmount { get; set; }

        // =========================================================
        // PAYMENT / STATUS
        // =========================================================

        public string? PaymentStatus { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        // =========================================================
        // AUDIT DETAILS
        // =========================================================

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}