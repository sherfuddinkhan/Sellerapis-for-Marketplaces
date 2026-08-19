public class SellerCustomerSalesInvoiceResponse
{
    public int SalesInvoiceId { get; set; }

    public int SellerId { get; set; }
    public int CustomerId { get; set; }

    public int SalesOrderId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;

    public DateTime InvoiceDate { get; set; }

    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal BalanceAmount { get; set; }

    public string? PaymentStatus { get; set; }
    public string? Status { get; set; }
    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}