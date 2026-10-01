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

        // Business
        [MaxLength(200)] public string? TradeName { get; set; }
        [MaxLength(200)] public string? LegalName { get; set; }
        [MaxLength(200)] public string? ContactPerson { get; set; }

        // Contact
        [MaxLength(150)] public string? Email { get; set; }
        [MaxLength(20)] public string? Phone { get; set; }

        // Tax
        [MaxLength(15)] public string? GSTIN { get; set; }

        // Address
        [MaxLength(200)] public string? AddressLine1 { get; set; }
        [MaxLength(200)] public string? AddressLine2 { get; set; }
        [MaxLength(200)] public string? BuildingName { get; set; }
        [MaxLength(200)] public string? Location { get; set; }
        [MaxLength(100)] public string? City { get; set; }
        [MaxLength(100)] public string? State { get; set; }
        [MaxLength(10)] public string? StateCode { get; set; }
        [MaxLength(50)] public string? FloorNo { get; set; }
        [MaxLength(100)] public string? Country { get; set; }
        [MaxLength(20)] public string? PostalCode { get; set; }

        // Financial
        public decimal? CreditLimit { get; set; }

        // Status
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        // Navigation
        [ForeignKey(nameof(SellerId))]
        public virtual Seller? Seller { get; set; }

        // Not mapped - populated by service, not EF
        [NotMapped] public List<StockMovement> StockMovements { get; set; } = [];
        [NotMapped] public List<StockLedger> StockLedgers { get; set; } = [];
        [NotMapped] public List<Warehouse> Warehouses { get; set; } = [];
    }
}