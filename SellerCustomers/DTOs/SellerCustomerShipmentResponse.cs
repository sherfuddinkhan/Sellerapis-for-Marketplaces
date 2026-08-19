namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerShipmentResponse
    {
        public int ShipmentId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int? SalesOrderId { get; set; }

        public int? DeliveryChallanId { get; set; }

        public string? ShipmentNumber { get; set; }
       
        public int OrderId { get; set; }

        public string? CourierName { get; set; }

        public string? TrackingNumber { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string? ShipmentStatus { get; set; }
        public string? CarrierName { get; set; }

        public string? Status { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }

        public string? ShippingAddress { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
