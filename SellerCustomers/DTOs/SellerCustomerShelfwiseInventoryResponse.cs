namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerShelfwiseInventoryResponse
    {
        public int ShelfwiseInventoryId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string FacilityCode { get; set; } = string.Empty;
        public string ShelfCode { get; set; } = string.Empty;
        public string ItemSkuCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? BatchCode { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? InventoryType { get; set; }
        public string? LocationCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // ===== ADDED - FROM DB =====
        public decimal? Mrp { get; set; }
        public long? Mfd { get; set; }
        public string? VendorCode { get; set; }
        public string? VendorBatchNumber { get; set; }
        public string? LotNumber { get; set; }
        public string? TransferToShelfCode { get; set; }
        public int? Sla { get; set; }
        public string? Remarks { get; set; }
        public int? WarehouseId { get; set; }
    }
}
