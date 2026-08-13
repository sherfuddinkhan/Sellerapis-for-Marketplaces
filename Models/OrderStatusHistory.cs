using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Models
{
    public class OrderStatusHistory
    {
        [Key]
        public int OrderStatusHistoryId { get; set; }

        public int OrderId { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? ChangedOn { get; set; }
    }
}