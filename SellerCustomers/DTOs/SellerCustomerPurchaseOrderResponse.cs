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
    }
}
