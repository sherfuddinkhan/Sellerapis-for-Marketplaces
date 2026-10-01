namespace Marketplacesellerportal.ExportJobs.DTOs
{
    public class UpdateExportJobDto
      : CreateExportJobDto
    {
        public string Status { get; set; } = "PENDING";

        public string? FileUrl { get; set; }
    }
}
