using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models;

[Table("facilityChannelInventories", Schema = "dbo")]
public class FacilityChannelInventory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sellerId")]
    public int SellerId { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("productId")]
    public int ProductId { get; set; }

    [Column("skuCode")]
    [MaxLength(100)]
    public string SkuCode { get; set; } = string.Empty;

    [Column("facilityCode")]
    [MaxLength(50)]
    public string FacilityCode { get; set; } = string.Empty;

    [Column("channelCode")]
    [MaxLength(50)]
    public string ChannelCode { get; set; } = string.Empty;

    [Column("sellableQuantity")]
    public int SellableQuantity { get; set; }
}
