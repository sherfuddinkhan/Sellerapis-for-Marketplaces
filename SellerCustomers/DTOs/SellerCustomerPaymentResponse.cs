namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPaymentResponse
    {
        public int PaymentId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int? SalesOrderId { get; set; }
        public int? SalesInvoiceId { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? TransactionReference { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
