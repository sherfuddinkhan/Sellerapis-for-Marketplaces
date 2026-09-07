namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSalesOrderItemResponse
    {
        public int SalesOrderItemId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }

        // =====================================================
        // TOPAZ PAYLOAD FIELDS - ADDED (77 missing params fix)
        // From TOPAZ invoiceProductDetails
        // =====================================================
        public string? Description { get; set; } // TechNova Wireless Bluetooth Headphones
        public string? Uom { get; set; } // PCS
        public string? Hsncode { get; set; } // 85183000
        public decimal? GstPer { get; set; } // 18
        public decimal? SgstPer { get; set; } // 9
        public decimal? SgstAmount { get; set; } // 4500
        public decimal? CgstPer { get; set; } // 9
        public decimal? CgstAmount { get; set; } // 4500
        public decimal? IgstPer { get; set; } // 0
        public decimal? IgstAmount { get; set; } // 0
        public decimal? AfterGSTAmount { get; set; } // 59000
        public decimal? QuantityAmount { get; set; } // 5000
        public decimal? TotalRateBeforeDiscount { get; set; }
        public string? TaxType { get; set; } // GST
        public int? BrandXID { get; set; } // 3 Samsung
        public string? Remarks { get; set; }
        public int? Pid { get; set; }
        public int? InvoiceXID { get; set; }
        public int? ItemXID { get; set; }
    }
}