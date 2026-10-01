using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("VendorItemCustomFields")]
    public class VendorItemCustomField
    {
        [Key]
        public int Id { get; set; }
        public int VendorItemMasterId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Value { get; set; }
    }
}
