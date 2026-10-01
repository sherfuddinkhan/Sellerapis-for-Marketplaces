namespace Marketplacesellerportal.DTOs
{
    public class PicklistDto
    {
        public int PicklistId { get; set; }

        public string PicklistCode { get; set; } = "PICK-001";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string? BinCode { get; set; } = "BIN-A1";

        public string? ShelfCode { get; set; } = "SHELF-01";

        public string Status { get; set; } = "CREATED";

        public string? AssignedTo { get; set; }
    }
}