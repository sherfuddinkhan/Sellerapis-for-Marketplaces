namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerProductTypeResponse
    {
        public int ProductTypeId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string ProductTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? ProductTypeCode { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNCode { get; set; }
        public decimal? GSTPercentage { get; set; }
        public bool? IsSystemDefined { get; set; }
        public int? DisplayOrder { get; set; }
        public string? ImageUrl { get; set; }
        public string? IconUrl { get; set; }
        public string? CreatedBy { get; set; }
    }
}
