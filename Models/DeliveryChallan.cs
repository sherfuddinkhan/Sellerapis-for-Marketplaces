namespace Marketplacesellerportal.Models
{
    public class DeliveryChallan
    {
        public int DeliveryChallanId { get; set; }

        public int SalesOrderId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        // Existing properties
        public string? ChallanNumber { get; set; }
        public DateTime? ChallanDate { get; set; }

        public string? VehicleNumber { get; set; }
        public string? DriverName { get; set; }
        public string? DriverMobile { get; set; }
        public string? TransporterName { get; set; }
        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
