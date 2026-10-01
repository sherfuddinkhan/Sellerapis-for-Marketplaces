namespace Marketplacesellerportal.Picklists.DTOs
{
    public class CreatePicklistDto
    {
        public string PicklistCode { get; set; } = "PICK-001";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string? BinCode { get; set; } = "BIN-A1";

        public string? ShelfCode { get; set; } = "SHELF-01";

        public string? AssignedTo { get; set; }
    }
}
