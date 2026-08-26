namespace Marketplacesellerportal.Payments.DTOs
{
    public class PaymentStatistics
    {
        // =========================================================
        // TOTAL PAYMENTS
        // =========================================================

        public int TotalPayments { get; set; }


        // =========================================================
        // TOTAL AMOUNT
        // =========================================================

        public decimal TotalAmount { get; set; }


        // =========================================================
        // PAYMENT STATUS
        // =========================================================

        public int PendingPayments { get; set; }

        public int CompletedPayments { get; set; }

        public int FailedPayments { get; set; }

        public int CancelledPayments { get; set; }


        // =========================================================
        // DISTINCT DATA
        // =========================================================

        public int DistinctOrders { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }


        // =========================================================
        // PAYMENT METHODS
        // =========================================================

        public int DistinctPaymentMethods { get; set; }


        // =========================================================
        // TRANSACTION INFORMATION
        // =========================================================

        public int TransactionsWithReference { get; set; }


        // =========================================================
        // DATE INFORMATION
        // =========================================================

        public DateTime? FirstPaymentDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }
    }
}
