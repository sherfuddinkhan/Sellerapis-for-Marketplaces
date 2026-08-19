namespace Marketplacesellerportal.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public string? CourierName { get; set; }

        public string? TrackingNumber { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string? ShipmentStatus { get; set; }
    }
}