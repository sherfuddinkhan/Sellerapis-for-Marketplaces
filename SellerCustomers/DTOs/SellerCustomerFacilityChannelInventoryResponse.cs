namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerFacilityChannelInventoryResponse
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public string SkuCode { get; set; } = string.Empty;

        public string FacilityCode { get; set; } = string.Empty;

        public string ChannelCode { get; set; } = string.Empty;

        public int SellableQuantity { get; set; }
    }
}
