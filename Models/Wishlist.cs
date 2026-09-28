using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        [NotMapped] public string WishlistName { get; set; }
        [NotMapped] public bool IsActive { get; set; }

        [NotMapped] public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
