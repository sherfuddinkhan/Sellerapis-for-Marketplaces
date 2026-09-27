public class SellerCustomerSalesInvoiceItemResponse
{
    public int SalesInvoiceItemId { get; set; }
    public int SalesInvoiceId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string HsnCode { get; set; }
    public decimal? GstPer { get; set; }
    public decimal? SgstPer { get; set; }
    public decimal? SgstAmount { get; set; }
    public decimal? CgstPer { get; set; }
    public decimal? CgstAmount { get; set; }
    public decimal? IgstPer { get; set; }
    public decimal? IgstAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal? AfterGSTAmount { get; set; }
    public string Uom { get; set; }
    public string Description { get; set; }
}
