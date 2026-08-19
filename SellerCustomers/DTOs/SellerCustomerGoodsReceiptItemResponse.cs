namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerGoodsReceiptItemResponse
    {
        public int GoodsReceiptItemId { get; set; }
        public int ProductId { get; set; }

        public decimal ReceivedQuantity { get; set; }
        public int GoodsReceiptNoteId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public decimal Quantity { get; set; }

        public decimal? AcceptedQuantity { get; set; }
        public decimal? RejectedQuantity { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
