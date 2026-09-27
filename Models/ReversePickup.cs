using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ReversePickups")]
    public class ReversePickup
    {
        [Key]
        [Column("ReversePickupId", TypeName = "INT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReversePickupId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string ReversePickupNo { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string SaleOrderCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string SaleOrderItemCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string ItemSkuCode { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [MaxLength(100)]
        public string TrackingNo { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string ReturnReason { get; set; }

        [Column(TypeName = "TEXT")]
        public string QCComment { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string ReversePickupStatus { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [MaxLength(100)]
        public string CourierProviderName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string FacilityCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string ChannelName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string PutawayCode { get; set; }

        // Base fields - multi-tenant pattern
        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}

