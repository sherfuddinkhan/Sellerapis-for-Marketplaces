namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerEInvoiceResponse
    {
        public int EInvoiceId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SalesInvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }

        // Uniware / GST E-Invoice fields - REQUIRED
        public string? Irn { get; set; }
        public string? AckNo { get; set; }
        public DateTime? AckDate { get; set; }
        public string? SignedInvoice { get; set; }
        public string? SignedQrCode { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
