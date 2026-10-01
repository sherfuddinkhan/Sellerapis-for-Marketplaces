namespace Marketplacesellerportal.DTOs
{
    public class InvoiceTaxDetailDto
    {
        public int InvoiceTaxDetailId { get; set; }

        public int InvoiceId { get; set; }

        public string TaxType { get; set; } = "GST";

        public decimal TaxRate { get; set; } = 18;

        public decimal TaxAmount { get; set; } = 180;

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string ChannelCode { get; set; } = "CUSTOM";
    }
}
