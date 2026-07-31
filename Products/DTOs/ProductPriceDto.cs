namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductPriceDto
    {
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal MRP { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxPercentage { get; set; }
    }
}