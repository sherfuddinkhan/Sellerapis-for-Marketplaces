using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ShelfwiseInventories")]
    public class ShelfwiseInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfwiseInventoryId { get; set; }

        // Made nullable - was causing SqlNullValueException
        public int? SellerId { get; set; }
        public int? CustomerId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? FacilityCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? ShelfCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? ItemSkuCode { get; set; }

        // Was int - now int? to handle NULL in DB
        public int? Quantity { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? BatchCode { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [StringLength(20)]
        public string? InventoryType { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? LocationCode { get; set; }

        // Was DateTime - now DateTime? to handle NULL
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        // ===== YOUR NEW FIELDS - All nullable safe =====
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal? Mrp { get; set; }

        [Column(TypeName = "BIGINT")]
        public long? Mfd { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? VendorCode { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string? VendorBatchNumber { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string? LotNumber { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string? TransferToShelfCode { get; set; }

        public int? Sla { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [StringLength(500)]
        public string? Remarks { get; set; }

        public int? WarehouseId { get; set; }
    }
}