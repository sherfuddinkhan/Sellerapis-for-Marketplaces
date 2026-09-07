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

        // =====================================================
        // TOPAZ PAYLOAD FIELDS - ADDED (20 fields)
        // From TOPAZ invoiceProductDetails
        // =====================================================

        public int? Pid { get; set; } // TOPAZ pid: 0
        public int? InvoiceXID { get; set; } // TOPAZ invoiceXID: 0

        public string? Description { get; set; } // TOPAZ description: Laptop sales record / TechNova Wireless Bluetooth Headphones

        public string? Uom { get; set; } // TOPAZ uom: PCS - maps to your unitOfMeasure

        public decimal? QuantityAmount { get; set; } // TOPAZ quantityAmount: 45000, 18000

        public int? InvoiceDiscountType { get; set; } // TOPAZ invoiceDiscountType: 0

        public decimal? InvoiceDiscountValue { get; set; } // TOPAZ invoiceDiscountValue: 0

        public decimal? InvoiceDiscountAmount { get; set; } // TOPAZ invoiceDiscountAmount: 0

        public decimal? TotalRateBeforeDiscount { get; set; } // TOPAZ totalRateBeforeDiscount: 0 - MRP

        public string? Hsncode { get; set; } // TOPAZ hsncode: 847130, 851712, 85183000

        public decimal? GstPer { get; set; } // TOPAZ gstPer: 18

        public decimal? SgstPer { get; set; } // TOPAZ sgstPer

        public decimal? SgstAmount { get; set; } // TOPAZ sgstAmount: 101250, 121500 - your 4500

        public decimal? CgstPer { get; set; } // TOPAZ cgstPer

        public decimal? CgstAmount { get; set; } // TOPAZ cgstAmount: 101250, 121500 - your 4500

        public decimal? IgstPer { get; set; } // TOPAZ igstPer

        public decimal? IgstAmount { get; set; } // TOPAZ igstAmount: 0

        public decimal? AfterGSTAmount { get; set; } // TOPAZ afterGSTAmount: 1327500, 1593000 - your 59000

        public DateTime? MfgDate { get; set; } // TOPAZ mfgDate

        public DateTime? ExpDate { get; set; } // TOPAZ expDate

        public string? Cases { get; set; } // TOPAZ cases

        public string? TaxType { get; set; } // TOPAZ taxType - GST

        public string? ColorCode { get; set; } // TOPAZ colorCode

        public decimal? ColorAmount { get; set; } // TOPAZ colorAmount

        public string? Remarks { get; set; } // TOPAZ remarks

        public int? ItemXID { get; set; } // TOPAZ itemXID

        public int? BrandXID { get; set; } // TOPAZ brandXID: null -> 3 (Samsung)

        // Extra TOPAZ fields
        public bool? IsReward { get; set; }
        public bool? IsAdditionalCharges { get; set; }
        public int? MaterialTypeXid { get; set; }
        public int? SpecificationTypeXid { get; set; }
        public int? ProjectAssetDetailXID { get; set; }
        public string? SpecificationTypeDetailName { get; set; }
        public bool? IsPurchasing { get; set; }

        // =====================================================
        // NAVIGATION PROPERTIES
        // =====================================================

        public SalesOrder? SalesOrder { get; set; }
        public Product? Product { get; set; }
    }
}