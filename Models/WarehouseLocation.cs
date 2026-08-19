using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("WarehouseLocations")]
    public class WarehouseLocation
    {
        [Key]
        public int LocationId { get; set; }

        public int CustomerId { get; set; }

        public int WarehouseId { get; set; }

        public string LocationCode { get; set; } = string.Empty;

        public string LocationName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}