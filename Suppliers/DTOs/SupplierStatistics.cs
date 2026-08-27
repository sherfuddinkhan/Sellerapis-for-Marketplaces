namespace Marketplacesellerportal.Suppliers.DTOs
{
    public class SupplierStatistics
    {
        public int TotalSuppliers { get; set; }

        public int ActiveSuppliers { get; set; }

        public int InactiveSuppliers { get; set; }

        public decimal TotalCreditLimit { get; set; }

        public decimal AverageCreditLimit { get; set; }
        public int SellerCount { get; set; }
    }
}
