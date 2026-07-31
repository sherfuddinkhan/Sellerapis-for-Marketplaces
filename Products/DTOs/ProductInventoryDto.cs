namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductInventoryDto
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int AvailableQuantity { get; set; }

        public int ReservedQuantity { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }
    }
}
