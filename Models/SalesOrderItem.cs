using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class SalesOrderItem
    {
        public int SalesOrderItemId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        // TOPAZ fields - already in DB
        public int? Pid { get; set; }
        public int? InvoiceXID { get; set; }
        public string? Description { get; set; }
        public string? Uom { get; set; }
        public decimal? QuantityAmount { get; set; }
        public int? InvoiceDiscountType { get; set; }
        public decimal? InvoiceDiscountValue { get; set; }
        public decimal? InvoiceDiscountAmount { get; set; }
        public decimal? TotalRateBeforeDiscount { get; set; }
        public string? Hsncode { get; set; }
        public decimal? GstPer { get; set; }
        public decimal? SgstPer { get; set; }
        public decimal? SgstAmount { get; set; }
        public decimal? CgstPer { get; set; }
        public decimal? CgstAmount { get; set; }
        public decimal? IgstPer { get; set; }
        public decimal? IgstAmount { get; set; }
        public decimal? AfterGSTAmount { get; set; }
        public DateTime? MfgDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string? Cases { get; set; }
        public string? TaxType { get; set; }
        public string? ColorCode { get; set; }
        public decimal? ColorAmount { get; set; }
        public string? Remarks { get; set; }
        public int? ItemXID { get; set; }
        public int? BrandXID { get; set; }
        public bool? IsReward { get; set; }
        public bool? IsAdditionalCharges { get; set; }
        public int? MaterialTypeXid { get; set; }
        public int? SpecificationTypeXid { get; set; }
        public int? ProjectAssetDetailXID { get; set; }
        public string? SpecificationTypeDetailName { get; set; }
        public bool? IsPurchasing { get; set; }

        // UNIWARE 11 fields - WE ADDED TODAY - KEEP ONLY THESE
        public string? Sku { get; set; }
        public string? ChannelSkuCode { get; set; }
        public string? ChannelProductId { get; set; }
        public string? VendorSkuCode { get; set; }
        public string? FacilityCode { get; set; }
        public string? Status { get; set; }
        public string? FulfillmentStatus { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? ChannelSaleOrderItemCode { get; set; }
        public int? PacketNumber { get; set; }

        [NotMapped]
        [MaxLength(200)] public string? ChannelProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SubTotal { get; set; }

        [NotMapped]
        public string? ProductName { get; set; }

        [NotMapped]
        public string? DisplayName { get; set; }

        // Uniware needs product name for invoice - add NotMapped
        [NotMapped]
    
        public SalesOrder? SalesOrder { get; set; }
        public Product? Product { get; set; }
    }
}