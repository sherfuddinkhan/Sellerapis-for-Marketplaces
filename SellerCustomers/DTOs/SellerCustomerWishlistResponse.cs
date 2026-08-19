namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerWishlistResponse
    {
        public int WishlistId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public string? WishlistName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
