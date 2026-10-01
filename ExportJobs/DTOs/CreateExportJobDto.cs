namespace Marketplacesellerportal.ExportJobs.DTOs
{
    public class CreateExportJobDto
    {
        public string JobCode { get; set; } = "EXP-001";

        public string ExportType { get; set; } = "Inventory";

        public string FacilityCode { get; set; } = "TN-WH-01";
    }
}
