public class SellerCustomerInventoryResponse
{
    public int ProductInventoryId { get; set; }

    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public int WarehouseId { get; set; }
    public int LocationId { get; set; }

    public decimal Quantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal DamagedQuantity { get; set; }

    public decimal ReorderLevel { get; set; }
    public decimal ReorderQuantity { get; set; }

    public DateTime? LastStockUpdate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
