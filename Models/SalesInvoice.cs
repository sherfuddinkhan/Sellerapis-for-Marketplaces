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
        // CUSTOMER / BUYER DETAILS - Snapshot
        // =========================================================
        public string? CompanyName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailAddress { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyState { get; set; }
        public string? CompanyPINCode { get; set; }
        public string? CustomerGSTIN { get; set; }

        // =========================================================
        // INVOICE DETAILS
        // =========================================================
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public string? InvoiceScenario { get; set; }
        public string? Category { get; set; }

        // TransactionType - REG, Bill To - Ship To, Bill From - Dispatch From, COMBINED
        public string? TransactionType { get; set; } = "REG";

        // =========================================================
        // TYPE 2 & 4 - SHIP TO (Consignee) - For einvoice.pdf
        // =========================================================
        public string? ShipToGSTIN { get; set; }
        public string? ShipToCompanyName { get; set; }
        public string? ShipToLegalName { get; set; }
        public string? ShipToAddress { get; set; }
        public string? ShipToCity { get; set; }
        public string? ShipToState { get; set; }
        public string? ShipToStateCode { get; set; }
        public string? ShipToPinCode { get; set; }
        public string? ShipToPhone { get; set; }
        public string? ShipToEmail { get; set; }

        // =========================================================
        // TYPE 3 & 4 - DISPATCH FROM (Ship From)
        // =========================================================
        public string? DispatchFromGSTIN { get; set; }
        public string? DispatchFromCompanyName { get; set; }
        public string? DispatchFromLegalName { get; set; }
        public string? DispatchFromAddress { get; set; }
        public string? DispatchFromCity { get; set; }
        public string? DispatchFromState { get; set; }
        public string? DispatchFromStateCode { get; set; }
        public string? DispatchFromPinCode { get; set; }
        public string? DispatchFromPhone { get; set; }

        // =========================================================
        // PURCHASE ORDER / REFERENCE DETAILS
        // =========================================================
        public string? PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string? OtherReferences { get; set; }
        public string? DespatchedDocumentNumber { get; set; }

        // =========================================================
        // GST / TAX DETAILS
        // =========================================================
        public string? UserGSTIN { get; set; }
        public string? DocumentType { get; set; }
        public string? SupplyType { get; set; }
        public string? PlaceOfSupply { get; set; }
        public string? FinancialYear { get; set; }
        public string? StateCode { get; set; }
        public bool ReverseCharge { get; set; }

        // =========================================================
        // DELIVERY / TRANSPORT DETAILS
        // =========================================================
        public string? DeliveryNote { get; set; }
        public DateTime? DeliveryNoteDate { get; set; }
        public string? EWayBillNumber { get; set; }
        public string? VehicleNo { get; set; }
        public string? Distance { get; set; }
        public string? Transport { get; set; }
        public string? TransporterName { get; set; }
        public string? TransporterID { get; set; }
        public string? TransporterDocNo { get; set; }
        public string? TransportMode { get; set; }
        public string? Destination { get; set; }
        public string? BillOfLandingOrLRRRNo { get; set; }
        public string? DespatchedThrough { get; set; }
        public string? ModeOrTermsOfPayment { get; set; }

        // =========================================================
        // E-INVOICE - IRN / QR - For your einvoice.pdf print
        // =========================================================
        public string? IrnNumber { get; set; }
        public string? AckNo { get; set; }
        public DateTime? AckDate { get; set; }
        public string? SignedQRCode { get; set; }
        public string? SignedInvoice { get; set; }

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
        public string? PaymentMode { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }

        // =========================================================
        // AUDIT DETAILS
        // =========================================================
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // =========================================================
        // NAVIGATION PROPERTIES
        // =========================================================
        public ICollection<SalesInvoiceItem>? Items { get; set; }
        public ICollection<SalesInvoicePayment>? Payments { get; set; }
        public ICollection<SalesInvoiceAdditionalCharge>? AdditionalCharges { get; set; }
    }
}