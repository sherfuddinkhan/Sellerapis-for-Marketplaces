using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
