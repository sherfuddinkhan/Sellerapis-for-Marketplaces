namespace Marketplacesellerportal.EInvoice.DTOs
{
    public class GenerateEinvoiceRequest
    {
        public string InvoiceNumber { get; set; } = "";
        public string SellerGstin { get; set; } = "";
        public string BuyerGstin { get; set; } = "";
        public string TransactionType { get; set; } = "REG";
        public string? ShipToGSTIN { get; set; }
        public string? ShipToCompanyName { get; set; }
        public string? DispatchFromGSTIN { get; set; }
        public string? DispatchFromCompanyName { get; set; }
    }
}
