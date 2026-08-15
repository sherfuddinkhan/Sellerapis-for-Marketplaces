using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int ReviewId { get; set; }

        public int CustomerId { get; set; }

        public int SellerId { get; set; }
      
        public int ProductId { get; set; }

        public int? Rating { get; set; }

        [Column("Review")]
        public string? ReviewText{ get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
