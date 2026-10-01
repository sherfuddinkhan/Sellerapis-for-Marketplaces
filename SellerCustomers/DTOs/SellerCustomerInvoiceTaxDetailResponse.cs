namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerInvoiceTaxDetailResponse
    {
        public int InvoiceTaxDetailId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public int? SalesInvoiceId { get; set; }

        public string? ChannelProductId { get; set; }

        public decimal? TaxPercentage { get; set; }

        public decimal? CentralGst { get; set; }

        public decimal? StateGst { get; set; }

        public decimal? IntegratedGst { get; set; }

        public decimal? CompensationCess { get; set; }
    }
}
