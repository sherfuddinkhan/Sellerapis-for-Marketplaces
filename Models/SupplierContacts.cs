using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("supplierContacts")]
    public class SupplierContacts
    {
        [Key]
        [Column("partyContactId")]
        public int PartyContactId { get; set; }

        [Column("supplierId")]
        public int SupplierId { get; set; }

        [Column("contactType")]
        public string? ContactType { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("ContactName")]
        public string? ContactName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("SellerId")]
        public int SellerId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        // NOT in DB - keep NotMapped
        [NotMapped]
        public int SupplierContactId { get; set; }
    }
}