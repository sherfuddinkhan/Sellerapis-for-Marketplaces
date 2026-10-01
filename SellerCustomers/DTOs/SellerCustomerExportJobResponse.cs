namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerExportJobResponse
    {
        public int ExportJobId { get; set; }

        public string JobCode { get; set; } = string.Empty;

        public string? ExportJobTypeName { get; set; }
        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public string? ExportColums { get; set; }

        public string? ExportFilters { get; set; }

        public DateTime? ScheduleTime { get; set; }

        public string? NotificationEmail { get; set; }

        public string? Frequency { get; set; }

        public string? ReportName { get; set; }

        public string? Status { get; set; }
    }
}
