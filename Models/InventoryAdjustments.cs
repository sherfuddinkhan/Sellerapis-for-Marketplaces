using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("InventoryAdjustmentLogs")]
    public class InventoryAdjustmentLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdjustmentId { get; set; }

        [MaxLength(50)]
        public string ItemSKU { get; set; }

        public int Quantity { get; set; }

        [MaxLength(50)]
        public string ShelfCode { get; set; }

        [MaxLength(30)]
        public string InventoryType { get; set; } = "GOOD_INVENTORY";

        [MaxLength(10)]
        public string AdjustmentType { get; set; }

        [MaxLength(50)]
        public string FacilityCode { get; set; }

        [MaxLength(50)]
        public string BatchCode { get; set; }

        [MaxLength(50)]
        public string TransferToShelfCode { get; set; }

        public int Sla { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
    }
}