namespace Marketplacesellerportal.EWayBill.DTOs
{
    public class GenerateEWayBillRequest
    {
        public string TransporterID { get; set; } = "";
        public string TransporterName { get; set; } = "VRL Logistics";
        public string TransportMode { get; set; } = "1"; // 1=Road, 2=Rail, 3=Air, 4=Ship
        public string VehicleNo { get; set; } = "TS09AB1234";
        public string Distance { get; set; } = "100";
        public string TransactionType { get; set; } = "REG";
        public string VehicleType { get; set; } = "R"; // R=Regular, O=ODC
    }
}
