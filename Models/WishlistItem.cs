using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class WishlistItem
    {
        [Key]
        public int WishlistItemId { get; set; }

        public int WishlistId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(WishlistId))]
        public Wishlist? Wishlist { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}