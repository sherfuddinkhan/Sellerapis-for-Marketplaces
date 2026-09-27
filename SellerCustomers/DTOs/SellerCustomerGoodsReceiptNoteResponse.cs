public class SellerCustomerGoodsReceiptNoteResponse
{
    public int GoodsReceiptNoteId { get; set; }
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public int PurchaseOrderId { get; set; }
    public string? PurchaseOrderNumber { get; set; }
    public string? GRNNumber { get; set; }
    public DateTime? ReceiptDate { get; set; }
    public string? Status { get; set; }
    public string? GRNStatus { get; set; }
    public string? Remarks { get; set; }

    // YOU MISSED - ADD THESE
    public int? WarehouseId { get; set; }
    public string? WarehouseCode { get; set; }
    public string? FacilityCode { get; set; }
    public string? LocationCode { get; set; }
    public string? VendorCode { get; set; }
    public string? VendorName { get; set; }
    public decimal? TotalQuantity { get; set; }
    public decimal? ReceivedQuantity { get; set; }
    public decimal? AcceptedQuantity { get; set; }
    public decimal? RejectedQuantity { get; set; }
    public decimal? TotalAmount { get; set; }
    public bool? IsQCRequired { get; set; }
    public bool? IsQCDone { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
}