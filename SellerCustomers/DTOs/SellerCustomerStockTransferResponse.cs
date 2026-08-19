namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerStockTransferResponse
    {
        public int StockTransferId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int FromWarehouseId { get; set; }

        public int ToWarehouseId { get; set; }

        public decimal Quantity { get; set; }

        public DateTime? TransferDate { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
