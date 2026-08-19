namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerDeliveryChallanResponse
    {
        public int DeliveryChallanId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public string? ChallanNumber { get; set; }
        public DateTime? ChallanDate { get; set; }

        public string? VehicleNumber { get; set; }
        public string? DriverName { get; set; }
        public string? DriverMobile { get; set; }
        public string? TransporterName { get; set; }
        public int? SalesOrderId { get; set; }

        public string? Status { get; set; }

        public string? DeliveryAddress { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
