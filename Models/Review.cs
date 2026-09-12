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

        public string? CustomerName { get; set; }

        public string? CustomerImage { get; set; }

        public bool VerifiedBuyer { get; set; }

        public string? ProductName { get; set; }

        public string? ProductSku { get; set; }

        public string? ProductImage { get; set; }

        public string? Marketplace { get; set; }

        public int Rating { get; set; }

        public string? ReviewTitle { get; set; }

        [Column("Review")]
        public string? ReviewText { get; set; }

        public int HelpfulCount { get; set; }

        public string? Status { get; set; }

        public string? ReviewImages { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}