using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("AmazonInventorySync")]
    public class AmazonInventorySync
    {
        [Key]
        public int InventorySyncId { get; set; }
        public int AmazonAccountId { get; set; }
        public int? ProductId { get; set; }
        public string? SKU { get; set; }
        public string? ASIN { get; set; }
        public string? MarketplaceId { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? ReservedQuantity { get; set; }
        public int? InboundQuantity { get; set; }
        public int? UnfulfillableQuantity { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public string? JsonData { get; set; }
    }
}
