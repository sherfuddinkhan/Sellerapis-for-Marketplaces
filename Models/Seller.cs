using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Sellers")]
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SellerCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string SellerName { get; set; } = string.Empty;

        // ==============================
        // BUSINESS / LEGAL DETAILS
        // ==============================

        [MaxLength(200)]
        public string TradeName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string LegalName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactPerson { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(15)]
        public string GSTIN { get; set; } = string.Empty;

        // ==============================
        // ADDRESS DETAILS
        // ==============================

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(200)]
        public string BuildingName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string State { get; set; } = string.Empty;

        [MaxLength(10)]
        public string StateCode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string FloorNo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        // ==============================
        // STATUS / AUDIT
        // ==============================

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}