using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.SalesInvoices.DTOs
{
    public class SalesInvoiceItemRequest
    {
        // =========================================================
        // PRODUCT / BASIC ITEM DETAILS
        // =========================================================

        [Required]
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        // =========================================================
        // REFERENCE DETAILS
        // =========================================================

        public int? Pid { get; set; }

        public int? InvoiceXID { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Uom { get; set; }

        public decimal? QuantityAmount { get; set; }

        public int? InvoiceDiscountType { get; set; }

        public decimal? InvoiceDiscountValue { get; set; }

        public decimal? InvoiceDiscountAmount { get; set; }

        public decimal? TotalRateBeforeDiscount { get; set; }

        [MaxLength(50)]
        public string? Hsncode { get; set; }

        // =========================================================
        // GST DETAILS
        // =========================================================

        public decimal? GstPer { get; set; }

        public decimal? SgstPer { get; set; }

        public decimal? SgstAmount { get; set; }

        public decimal? CgstPer { get; set; }

        public decimal? CgstAmount { get; set; }

        public decimal? IgstPer { get; set; }

        public decimal? IgstAmount { get; set; }

        public decimal? AfterGSTAmount { get; set; }

        [MaxLength(100)]
        public string? TaxType { get; set; }

        // =========================================================
        // PRODUCT ADDITIONAL DETAILS
        // =========================================================

        public DateTime? MfgDate { get; set; }

        public DateTime? ExpDate { get; set; }

        [MaxLength(100)]
        public string? Cases { get; set; }

        [MaxLength(100)]
        public string? ColorCode { get; set; }

        public decimal? ColorAmount { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        public int? ItemXID { get; set; }

        public int? BrandXID { get; set; }

        // =========================================================
        // FLAGS / OTHER REFERENCES
        // =========================================================

        public bool? IsReward { get; set; }

        public bool? IsAdditionalCharges { get; set; }

        public int? MaterialTypeXid { get; set; }

        public int? SpecificationTypeXid { get; set; }

        public int? ProjectAssetDetailXID { get; set; }

        [MaxLength(500)]
        public string? SpecificationTypeDetailName { get; set; }

        public bool? IsPurchasing { get; set; }
    }
}
