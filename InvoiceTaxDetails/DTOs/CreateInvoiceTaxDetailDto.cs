namespace Marketplacesellerportal.InvoiceTaxDetails.DTOs
{
    public class CreateInvoiceTaxDetailDto
    {
        public int InvoiceId { get; set; }

        public string TaxType { get; set; } = "GST";

        public decimal TaxRate { get; set; } = 18;

        public decimal TaxAmount { get; set; } = 180;
    }
}
