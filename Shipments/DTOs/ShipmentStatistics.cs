namespace Marketplacesellerportal.Shipments.DTOs
{
    public class ShipmentStatistics
    {
        public int TotalShipments { get; set; }

        public int DeliveredShipments { get; set; }

        public int PendingShipments { get; set; }

        public int CancelledShipments { get; set; }

        public int InTransitShipments { get; set; }
    }
}
