namespace Marketplacesellerportal.Models
{
    public class EWayBill
    {
        public int EWayBillId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SalesInvoiceId { get; set; }
        public string? EWayBillNumber { get; set; }
        public DateTime? EWayBillDate { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }


        // ✅ NEW DYNAMIC FIELDS
        public string? VehicleNo { get; set; }
        public string? TransporterName { get; set; }
        public string? TransporterID { get; set; }
        public string? TransporterDocNo { get; set; }
        public string? Distance { get; set; }
        public string? TransportMode { get; set; }
        public string? VehicleType { get; set; }
        public string? TransactionType { get; set; } // 1=Supply
    }
}
