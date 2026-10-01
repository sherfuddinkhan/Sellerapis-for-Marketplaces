namespace Marketplacesellerportal.Picklists.DTOs
{
    public class UpdatePicklistDto
       : CreatePicklistDto
    {
        public string Status { get; set; } = "CREATED";
    }
}
