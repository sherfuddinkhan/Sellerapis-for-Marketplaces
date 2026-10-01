using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("VendorItemCustomFields")] // Try capital V - your DB has this
    public class VendorItemCustomField
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("VendorItemMasterId")]
        public int VendorItemMasterId { get; set; }

        [Column("Name")]
        public string? Name { get; set; } // make nullable!

        [Column("Value")]
        public string? Value { get; set; } // make nullable!

        [Column("SellerId")]
        public int SellerId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        // NOT in DB
        [NotMapped]
        public string? FieldName { get; set; }
        [NotMapped]
        public string? FieldValue { get; set; }
        [NotMapped]
        public int VendorItemCustomFieldId => Id;
        [NotMapped]
        public int? SupplierId { get; set; }
        [NotMapped]
        public DateTime? CreatedDate { get; set; }
    }
}