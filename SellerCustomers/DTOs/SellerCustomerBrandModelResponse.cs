namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerBrandModelResponse
    {
        public int BrandModelId { get; set; }
        public int BrandId { get; set; }
        public int SellerId { get; set; } // ✅ ADD
        public int CustomerId { get; set; } // ✅ ADD
        public string ModelName { get; set; } = string.Empty;
        public string ModelCode { get; set; } = string.Empty;
        public string? BrandName { get; set; } // ✅ ADD
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string? Specifications { get; set; }
        public string? ImageUrl { get; set; }
    }
}