namespace Marketplacesellerportal.DTOs
{
    public class ExportJobDto
    {
        public int ExportJobId { get; set; }

        public string JobCode { get; set; } = "EXP-001";

        public string ExportType { get; set; } = "Inventory";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string ChannelCode { get; set; } = "CUSTOM";

        public string Status { get; set; } = "PENDING";

        public string? FileUrl { get; set; }
    }
}
