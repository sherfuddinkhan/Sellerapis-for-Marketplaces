using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SalesInvoices.DTOs
{
    public class UpdateSalesInvoiceRequest
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
        // CUSTOMER / BUYER SNAPSHOT
        // =========================================================

        [MaxLength(250)]
        public string? CompanyName { get; set; }

        [MaxLength(30)]
        public string? MobileNo { get; set; }

        [MaxLength(250)]
        public string? EmailAddress { get; set; }

        [MaxLength(500)]
        public string? CompanyAddress { get; set; }

        [MaxLength(100)]
        public string? CompanyCity { get; set; }

        [MaxLength(100)]
        public string? CompanyState { get; set; }

        [MaxLength(20)]
        public string? CompanyPINCode { get; set; }

        [MaxLength(15)]
        public string? CustomerGSTIN { get; set; }

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
        // PO / REFERENCE DETAILS
        // =========================================================

        [MaxLength(100)]
        public string? PurchaseOrderNo { get; set; }

        public DateTime? PurchaseOrderDate { get; set; }

        [MaxLength(500)]
        public string? OtherReferences { get; set; }

        [MaxLength(100)]
        public string? DespatchedDocumentNumber { get; set; }

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
        public string? StateCode { get; set; }

        [MaxLength(20)]
        public string? FinancialYear { get; set; }

        public bool ReverseCharge { get; set; }

        // =========================================================
        // TRANSPORT / DELIVERY DETAILS
        // =========================================================

        [MaxLength(250)]
        public string? DeliveryNote { get; set; }

        public DateTime? DeliveryNoteDate { get; set; }

        [MaxLength(100)]
        public string? EWayBillNumber { get; set; }

        [MaxLength(100)]
        public string? VehicleNo { get; set; }

        [MaxLength(50)]
        public string? Distance { get; set; }

        [MaxLength(250)]
        public string? Transport { get; set; }

        [MaxLength(250)]
        public string? TransporterName { get; set; }

        [MaxLength(100)]
        public string? TransporterID { get; set; }

        [MaxLength(100)]
        public string? TransporterDocNo { get; set; }

        [MaxLength(100)]
        public string? TransportMode { get; set; }

        [MaxLength(250)]
        public string? Destination { get; set; }

        [MaxLength(150)]
        public string? BillOfLandingOrLRRRNo { get; set; }

        [MaxLength(250)]
        public string? DespatchedThrough { get; set; }

        [MaxLength(250)]
        public string? ModeOrTermsOfPayment { get; set; }

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

        [MaxLength(100)]
        public string? PaymentMode { get; set; }

        [MaxLength(50)]
        public string? PaymentStatus { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        // =========================================================
        // CHILD COLLECTIONS
        // =========================================================

        public List<SalesInvoiceItemRequest> Items { get; set; }
            = new();

        public List<SalesInvoicePaymentRequest> Payments { get; set; }
            = new();

        public List<SalesInvoiceAdditionalChargeRequest> AdditionalCharges { get; set; }
            = new();
    }
}