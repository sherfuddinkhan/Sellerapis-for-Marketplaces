using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("SellerCustomers")]
    public class SellerCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public int SellerId { get; set; }

        [MaxLength(50)]
        public string? CustomerCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? ContactPerson { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(15)]
        public string? GSTIN { get; set; }

        [MaxLength(200)]
        public string? AddressLine1 { get; set; }

        [MaxLength(200)]
        public string? AddressLine2 { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        public decimal? CreditLimit { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // =========================================================
        // RELATED ENTITIES
        // =========================================================

        [NotMapped]
        public List<StockMovement> StockMovements { get; set; }
            = new List<StockMovement>();

        [NotMapped]
        public List<StockLedger> StockLedgers { get; set; }
            = new List<StockLedger>();

        [NotMapped]
        public List<Warehouse> Warehouses { get; set; }
            = new List<Warehouse>();
    }
}