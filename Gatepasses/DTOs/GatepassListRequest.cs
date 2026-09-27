namespace Marketplacesellerportal.Gatepasses.DTOs
{
    public class GatepassListRequest
    {
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string? GatepassCode { get; set; }
        public string? FacilityCode { get; set; }
        public string? ItemSkuCode { get; set; }
        public string? Status { get; set; }
        public string? Facility { get; set; }
        public string? SearchText { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? SortBy { get; set; } = "CreatedDate";
        public string? SortOrder { get; set; } = "DESC";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int Page { get => PageNumber; set => PageNumber = value; }
    }
}