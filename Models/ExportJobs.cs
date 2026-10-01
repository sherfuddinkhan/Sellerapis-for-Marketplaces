using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ExportJobs")]
    public class ExportJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ExportJobId")]
        public int ExportJobId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("jobCode")]
        public string JobCode { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("exportJobTypeName")]
        public string? ExportJobTypeName { get; set; }

        [Column("exportColums", TypeName = "text")]
        public string? ExportColums { get; set; }

        [Column("exportFilters", TypeName = "text")]
        public string? ExportFilters { get; set; }

        [Column("scheduleTime")]
        public DateTime? ScheduleTime { get; set; }

        [MaxLength(100)]
        [Column("notificationEmail")]
        public string? NotificationEmail { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        [MaxLength(20)]
        [Column("frequency")]
        public string? Frequency { get; set; }

        [MaxLength(100)]
        [Column("reportName")]
        public string? ReportName { get; set; }

        [MaxLength(20)]
        [Column("status")]
        public string? Status { get; set; }
    }
}