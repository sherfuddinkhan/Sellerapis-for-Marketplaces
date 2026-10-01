using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("InvoiceTaxDetails")]
    public class InvoiceTaxDetail
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceTaxDetailId { get; set; }

        [Column("salesInvoiceId")]
        public int? SalesInvoiceId { get; set; }

        [Column("channelProductId")]
        [MaxLength(255)]
        public string? ChannelProductId { get; set; }

        [Column("taxPercentage")]
        public decimal? TaxPercentage { get; set; }

        [Column("centralGst")]
        public decimal? CentralGst { get; set; }

        [Column("stateGst")]
        public decimal? StateGst { get; set; }

        [Column("integratedGst")]
        public decimal? IntegratedGst { get; set; }

        [Column("compensationCess")]
        public decimal? CompensationCess { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
    }
}