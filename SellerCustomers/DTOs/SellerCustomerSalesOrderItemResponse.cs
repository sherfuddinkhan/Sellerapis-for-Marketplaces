namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSalesOrderItemResponse
    {
        public int SalesOrderItemId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }

        // =====================================================
        // UNIWARE 11 - FIXED CASE (lowercase to match JSON)
        // =====================================================
        public string? Sku { get; set; } // was SKU - FIX CASE
        public string? ChannelSkuCode { get; set; }
        public string? ChannelProductId { get; set; }
        public string? VendorSkuCode { get; set; }
        public string? ChannelProductName { get; set; } // optional
        public string? FacilityCode { get; set; } = "WH-TN-001";
        public string? Status { get; set; } = "CREATED";
        public string? FulfillmentStatus { get; set; } = "PENDING";
        public decimal? Mrp { get; set; } // was MRP - FIX CASE
        public decimal? SellingPrice { get; set; }
        public string? ChannelSaleOrderItemCode { get; set; }
        public int? PacketNumber { get; set; }

        // Uniware extras (optional - keep nullable)
        public string? ItemTypeCode { get; set; }
        public string? ProductName { get; set; }
        public string? DisplayName { get; set; }
        public int? WarehouseId { get; set; }
        public decimal? TransferPrice { get; set; }
        public decimal? Weight { get; set; }

        // =====================================================
        // ORDER QTY/PRICE
        // =====================================================
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? SubTotal { get; set; }

        // =====================================================
        // TOPAZ GST FIELDS
        // =====================================================
        public string? Description { get; set; }
        public string? Uom { get; set; }
        public string? Hsncode { get; set; }
        public decimal? GstPer { get; set; }
        public decimal? SgstPer { get; set; }
        public decimal? SgstAmount { get; set; }
        public decimal? CgstPer { get; set; }
        public decimal? CgstAmount { get; set; }
        public decimal? IgstPer { get; set; }
        public decimal? IgstAmount { get; set; }
        public decimal? CessPer { get; set; }
        public decimal? CessAmount { get; set; }
        public decimal? AfterGSTAmount { get; set; }
        public decimal? QuantityAmount { get; set; }
        public decimal? TotalRateBeforeDiscount { get; set; }
        public decimal? Rate { get; set; }
        public string? TaxType { get; set; }
        public int? BrandXID { get; set; }
        public string? Remarks { get; set; }
        public int? Pid { get; set; }
        public int? InvoiceXID { get; set; }
        public int? ItemXID { get; set; }
        public string? BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}