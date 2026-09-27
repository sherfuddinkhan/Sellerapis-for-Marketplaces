namespace Marketplacesellerportal.EInvoice.DTOs
{
    public class EinvoiceResponse
    {
        public string IrnNumber { get; set; } = "";
        public string AckNo { get; set; } = "";
        public DateTime AckDate { get; set; }
        public string SignedQRCode { get; set; } = "";
        public string SignedInvoice { get; set; } = "";
        public string Status { get; set; } = "Success";
    }
}
