using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Picklists")]
    public class Picklist
    {
        [Key]
        [MaxLength(50)]
        public string PicklistCode { get; set; }
        [MaxLength(20)]
        public string Destination { get; set; } = "INVOICING";
        public string ShippingPackageCodes { get; set; } // JSON ["SP-10"]

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int PicklistId { get; set; }
        
    }
}
