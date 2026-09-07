namespace Marketplacesellerportal.WishlistItems.DTOs
{
    public class WishlistItemCreateDto
    {
        public int WishlistId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
