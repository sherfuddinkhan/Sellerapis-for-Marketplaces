namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerBrandModelResponse
    {
        public int BrandModelId { get; set; }

        public int BrandId { get; set; }

        public string ModelName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
