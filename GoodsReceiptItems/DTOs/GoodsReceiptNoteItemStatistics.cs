namespace Marketplacesellerportal.GoodsReceiptItems.DTOs
{
    public class GoodsReceiptNoteItemStatistics
    {
        public int TotalItems { get; set; }

        public decimal TotalReceivedQuantity { get; set; }

        public decimal TotalAcceptedQuantity { get; set; }

        public decimal TotalRejectedQuantity { get; set; }

        public int DistinctProducts { get; set; }

        public int DistinctGoodsReceiptNotes { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }
    }
}


