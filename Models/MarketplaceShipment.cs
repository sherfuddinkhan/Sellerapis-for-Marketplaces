using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceSellerPortal.Models
{
    [Table("MarketplaceShipments")]
    public class MarketplaceShipment
    {
        [Key]
        public int MarketplaceShipmentId { get; set; }

        public int MarketplaceOrderId { get; set; }

        [MaxLength(100)]
        public string? ShipmentNumber { get; set; }

        [MaxLength(150)]
        public string? Carrier { get; set; }

        [MaxLength(150)]
        public string? TrackingNumber { get; set; }

        [MaxLength(100)]
        public string? ShippingService { get; set; }

        public DateTime? ShipDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [MaxLength(100)]
        public string? ShipmentStatus { get; set; }

        public decimal? ShippingCost { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
