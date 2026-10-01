namespace Marketplacesellerportal.ReversePickupAddresses.DTOs
{
    public class CreateReversePickupAddressDto
    {
        public int ReversePickupId { get; set; }
        public string AddressLine1 { get; set; } = "";
        public string City { get; set; } = "";
        public string Pincode { get; set; } = "";
    }
}
