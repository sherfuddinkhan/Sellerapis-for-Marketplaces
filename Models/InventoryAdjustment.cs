using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.Models
{
    [Table("InventoryAdjustments")]
    public class InventoryAdjustment
    {
        [Key]
        public int InventoryAdjustmentId { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }

        public int? WarehouseLocationId { get; set; }

        [MaxLength(50)]
        public string AdjustmentType { get; set; } = "ADJUSTMENT";

        public int Quantity { get; set; }

        public int? PreviousQuantity { get; set; }

        public int? NewQuantity { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        [MaxLength(100)]
        public string? ReferenceNumber { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
