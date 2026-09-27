namespace Marketplacesellerportal.EWayBill.DTOs
{
    public class EWayBillResponse
    {
        public string EWayBillNo { get; set; } = "";
        public DateTime EWayBillDate { get; set; }
        public string ValidUpto { get; set; } = "";
        public string Status { get; set; } = "Success";
    }
}
