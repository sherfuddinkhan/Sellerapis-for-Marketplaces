using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Models
{
    [Table("SupplierContacts")]
    public class SupplierContacts
    {
        [Key]
        public int PartyContactId { get; set; }
        public int SupplierId { get; set; }
        [MaxLength(20)]
        public string ContactType { get; set; } = "PRIMARY";
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        public int SupplierContactId { get; set; }
    }

}
