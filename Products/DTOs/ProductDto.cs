namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public string Barcode { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public string HSNCode { get; set; } = string.Empty;

        public string TaxCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}