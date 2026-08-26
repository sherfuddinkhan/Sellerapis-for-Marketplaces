namespace Marketplacesellerportal.ProductInventories.DTOs
{
    public class ProductInventoryModel
    {
        public int ProductInventoryId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int LocationId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? ReservedQuantity { get; set; }

        public decimal? DamagedQuantity { get; set; }

        public decimal? ReorderLevel { get; set; }

        public decimal? ReorderQuantity { get; set; }

        public DateTime? LastStockUpdate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // Calculated fields for UI

        public decimal AvailableQuantity
        {
            get
            {
                return
                    (Quantity ?? 0)
                    - (ReservedQuantity ?? 0)
                    - (DamagedQuantity ?? 0);
            }
        }

        public string StockStatus
        {
            get
            {
                var quantity = Quantity ?? 0;
                var reorderLevel = ReorderLevel ?? 0;

                if (quantity <= 0)
                    return "out_of_stock";

                if (quantity <= reorderLevel)
                    return "low_stock";

                return "in_stock";
            }
        }
    }
}
