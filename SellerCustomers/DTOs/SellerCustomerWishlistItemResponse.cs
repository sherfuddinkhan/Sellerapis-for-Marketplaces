namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerWishlistItemResponse
    {
        public int WishlistItemId { get; set; }

        public int WishlistId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
