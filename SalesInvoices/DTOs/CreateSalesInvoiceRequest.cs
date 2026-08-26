using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SalesInvoices.DTOs
{
    public class CreateSalesInvoiceRequest
    {
        // =========================================================
        // REFERENCE DETAILS
        // =========================================================

        [Required]
        public int SalesOrderId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        // =========================================================
        // INVOICE DETAILS
        // =========================================================

        [Required]
        [MaxLength(100)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        public DateTime InvoiceDate { get; set; }

        [MaxLength(100)]
        public string? InvoiceScenario { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        [MaxLength(100)]
        public string? TransactionType { get; set; }

        // =========================================================
        // GST / TAX DETAILS
        // =========================================================

        [MaxLength(15)]
        public string? UserGSTIN { get; set; }

        [MaxLength(100)]
        public string? DocumentType { get; set; }

        [MaxLength(100)]
        public string? SupplyType { get; set; }

        [MaxLength(100)]
        public string? PlaceOfSupply { get; set; }

        [MaxLength(20)]
        public string? FinancialYear { get; set; }

        public bool ReverseCharge { get; set; }

        // =========================================================
        // ID / REFERENCE DETAILS
        // =========================================================

        [MaxLength(100)]
        public string? Id { get; set; }

        [MaxLength(100)]
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

        [MaxLength(50)]
        public string? PaymentStatus { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }
    }
}
