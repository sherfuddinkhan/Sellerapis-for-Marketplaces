namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerCategoryResponse
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string? CategoryCode { get; set; }
        public string? ParentCategoryName { get; set; }
        public int? Level { get; set; }
        public string? HSNCode { get; set; }
        public decimal? GSTPercentage { get; set; }
        public bool? IsSystemDefined { get; set; }
        public int? DisplayOrder { get; set; }
        public string? ImageUrl { get; set; }
        public string? IconUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? CreatedBy { get; set; }
    }
}
