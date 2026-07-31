using System;

namespace Marketplacesellerportal.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // Self-referencing navigation (optional)
        public virtual Category? ParentCategory { get; set; }
    }
}
