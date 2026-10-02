public class SellerCustomerInventoryResponse
{
    public int ProductInventoryId { get; set; }
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int? WarehouseId { get; set; }
    public int? LocationId { get; set; }

    public decimal Quantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal DamagedQuantity { get; set; }
    public decimal ReorderLevel { get; set; }
    public decimal ReorderQuantity { get; set; }

    public DateTime? LastStockUpdate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // --- Uniware fields to get their values in your model ---
    public string? SKU { get; set; } 
    public string? Barcode { get; set; } 
    public string? WarehouseCode { get; set; }
    public string? FacilityCode { get; set; } 

    public bool IsFacilityCodeMatch { get; set; } 
    public string? ChannelCode { get; set; } 
 
    public bool IsChannelCodeMatch { get; set; } 
    public string? LocationCode { get; set; } 
    public string? LocationName { get; set; } 
    public string? BatchId { get; set; }
    public decimal? ChannelPrice { get; set; }
    public bool IsBulkUpload { get; set; }
    public string? BulkStatus { get; set; } 
    public string? AdjustmentType { get; set; }
    public int? AdjustmentQuantity { get; set; }

    // Computed for Uniware Dashboard
    public decimal SellableQuantity { get; set; } 
    public decimal Inventory { get; set; } 
    public decimal ChannelInventory { get; set; } 


    public string? ProductName { get; set; }
    public bool? IsSynced { get; set; }
    public DateTime? SyncDate { get; set; }
    public string? ItemCode { get; set; }
}