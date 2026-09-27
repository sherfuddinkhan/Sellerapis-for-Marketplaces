using System;
using System.ComponentModel.DataAnnotations;
namespace Marketplacesellerportal.DTOs
{
    public class ShelfwiseInventoryListRequest
    {
        [Required] public int SellerId { get; set; }
        [Required] public int CustomerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? SearchTerm { get; set; }
        public string? FacilityCode { get; set; }
        public string? ShelfCode { get; set; }
        public string? ItemSkuCode { get; set; }
        public string? BatchCode { get; set; }
        public string? InventoryType { get; set; }
        public string? SortBy { get; set; } = "CreatedDate";
        public string SortOrder { get; set; } = "DESC";
        public void Normalize() { if (PageNumber < 1) PageNumber = 1; if (PageSize < 1) PageSize = 10; if (PageSize > 100) PageSize = 100; }
    }
}