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
        public DateTime? ReturnDate { get; set; }
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
        public string? SalesOrderNumber { get; set; }
        public string? DisplayOrderCode { get; set; }
        public string? ShippingPackageCode { get; set; }
        public string? ShippingPackageNumber { get; set; }
        public string? ChannelCode { get; set; }
        public string? FacilityCode { get; set; }
        public string? CourierCode { get; set; }
        public string? ShippingMethodCode { get; set; }
        public string? AwbNumber { get; set; }
        public string? CourierTrackingUrl { get; set; }
        public string? ShippingLabelUrl { get; set; }
        public string? InvoiceUrl { get; set; }
        public bool IsCod { get; set; }
        public decimal? CodAmount { get; set; }
        public string? ShippingPackageStatus { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool IsShipped { get; set; }
        public bool IsDelivered { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // === ADD THESE 10 - YOU MISSED - FIXES BUILD ERROR ===
        public string? DimUnit { get; set; } = "CM";
        public string? WeightUnit { get; set; } = "KG";
        public string? VehicleNo { get; set; }
        public string? TransporterName { get; set; }
        public string? TransporterID { get; set; }
        public string? TransporterDocNo { get; set; }
        public string? TransportMode { get; set; } = "Road Transport";
        public string? Distance { get; set; }
        public string? EWayBillNumber { get; set; }
        public decimal? ShippingCharges { get; set; } = 0;
        public decimal? TotalAmount { get; set; }

        // === ADD THESE 2 FOR UNIWARE STATUS ===
        public string? CourierStatus { get; set; }
        public string? StatusRemarks { get; set; }
        public string? UniwareFacilityCode { get; set; }
    }
}