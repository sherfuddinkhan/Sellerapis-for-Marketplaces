using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Marketplacesellerportal.Models
{
    public class SalesInvoiceItem
    {
        // =====================================================
        // PRIMARY KEY
        // =====================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesInvoiceItemId { get; set; }


        // =====================================================
        // INVOICE / PRODUCT RELATIONSHIP
        // =====================================================

        public int SalesInvoiceId { get; set; }

        public int ProductId { get; set; }


        // =====================================================
        // BASIC ITEM / PRICE DETAILS
        // Consistent with SalesOrderItem
        // =====================================================

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }


        // =====================================================
        // TOPAZ / INVOICE PRODUCT DETAILS
        // =====================================================

        public int? Pid { get; set; }

        public int? InvoiceXID { get; set; }

        public string? Description { get; set; }

        public string? Uom { get; set; }

        public decimal? QuantityAmount { get; set; }


        // =====================================================
        // DISCOUNT DETAILS
        // =====================================================

        public int? InvoiceDiscountType { get; set; }

        public decimal? InvoiceDiscountValue { get; set; }

        public decimal? InvoiceDiscountAmount { get; set; }

        public decimal? TotalRateBeforeDiscount { get; set; }


        // =====================================================
        // PRODUCT / TAX IDENTIFICATION
        // =====================================================

        public string? Hsncode { get; set; }


        // =====================================================
        // GST DETAILS
        // =====================================================

        public decimal? GstPer { get; set; }

        public decimal? SgstPer { get; set; }

        public decimal? SgstAmount { get; set; }

        public decimal? CgstPer { get; set; }

        public decimal? CgstAmount { get; set; }

        public decimal? IgstPer { get; set; }

        public decimal? IgstAmount { get; set; }

        public decimal? AfterGSTAmount { get; set; }

        public string? TaxType { get; set; }


        // =====================================================
        // MANUFACTURING / EXPIRY
        // =====================================================

        public DateTime? MfgDate { get; set; }

        public DateTime? ExpDate { get; set; }


        // =====================================================
        // PRODUCT / PACKAGING DETAILS
        // =====================================================

        public string? Cases { get; set; }

        public string? ColorCode { get; set; }

        public decimal? ColorAmount { get; set; }


        // =====================================================
        // REFERENCES
        // =====================================================

        public string? Remarks { get; set; }

        public int? ItemXID { get; set; }

        public int? BrandXID { get; set; }


        // =====================================================
        // EXTRA TOPAZ FIELDS
        // =====================================================

        public bool? IsReward { get; set; }

        public bool? IsAdditionalCharges { get; set; }

        public int? MaterialTypeXid { get; set; }

        public int? SpecificationTypeXid { get; set; }

        public int? ProjectAssetDetailXID { get; set; }

        public string? SpecificationTypeDetailName { get; set; }

        public bool? IsPurchasing { get; set; }


        [JsonIgnore]
        public SalesInvoice? SalesInvoice { get; set; }

        public Product? Product { get; set; }
    }
}
