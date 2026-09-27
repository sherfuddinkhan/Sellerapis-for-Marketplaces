namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPurchaseOrderResponse
    {
        public int PurchaseOrderId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int? SupplierId { get; set; }

        public int? WarehouseId { get; set; }
 
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? PurchaseOrderNumber { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Currency { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? PurchaseOrderCode { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string? POStatus { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? FacilityCode { get; set; }
        public string? VendorCode { get; set; }
        public string? VendorName { get; set; }
        public string? ChannelCode { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? PendingQuantity { get; set; }
        public string? CreatedBy { get; set; }
    }
}
