namespace Marketplacesellerportal.Models
{
    public class CustomerReturn
    {
        public int CustomerReturnId { get; set; }

        public int SalesInvoiceId { get; set; }

        public int ProductId { get; set; }

        public string ReturnNumber { get; set; } = string.Empty;

        public DateTime? ReturnDate { get; set; }

        public decimal Quantity { get; set; }

        public decimal ReturnAmount { get; set; }

        public string? Reason { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        // SellerCustomer mapping
        public int SellerId { get; set; }

        public int CustomerId { get; set; }
    }
}