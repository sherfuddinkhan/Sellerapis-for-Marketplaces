namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerTransactionResponse
    {
        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public List<SellerCustomerCustomerReturnResponse> CustomerReturns { get; set; } = new();
        public List<SellerCustomerDeliveryChallanResponse> DeliveryChallans { get; set; } = new();
        public List<SellerCustomerGoodsReceiptItemResponse> GoodsReceiptItems { get; set; } = new();
        public List<SellerCustomerGoodsReceiptNoteResponse> GoodsReceiptNotes { get; set; } = new();
        public List<SellerCustomerNotificationResponse> Notifications { get; set; } = new();
        public List<SellerCustomerOrderStatusHistoryResponse> OrderStatusHistories { get; set; } = new();
        public List<SellerCustomerPaymentResponse> Payments { get; set; } = new();
        public List<SellerCustomerPurchaseOrderResponse> PurchaseOrders { get; set; } = new();
        public List<SellerCustomerPurchaseOrderItemResponse> PurchaseOrderItems { get; set; } = new();
        public List<SellerCustomerPurchaseReturnResponse> PurchaseReturns { get; set; } = new();
        public List<SellerCustomerReviewResponse> Reviews { get; set; } = new();
        public List<SellerCustomerSalesInvoiceResponse> SalesInvoices { get; set; } = new();
        public List<SellerCustomerSalesOrderResponse> SalesOrders { get; set; } = new();
        public List<SellerCustomerSalesOrderItemResponse> SalesOrderItems { get; set; } = new();
        public List<SellerCustomerShipmentResponse> Shipments { get; set; } = new();
        public List<SellerCustomerWishlistResponse> Wishlists { get; set; } = new();
        public List<SellerCustomerWishlistItemResponse> WishlistItems { get; set; } = new();
    }
}