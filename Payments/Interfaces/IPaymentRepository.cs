using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.DTOs;

namespace Marketplacesellerportal.Payments.Interfaces
{
    public interface IPaymentRepository
    {
        // =========================================================
        // PAYMENT
        // =========================================================

        Task<IEnumerable<Payment>> GetAllAsync();

        Task<Payment?> GetByIdAsync(
            int paymentId);

        Task<IEnumerable<Payment>> GetByOrderIdAsync(
            int orderId);

        Task<IEnumerable<Payment>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<Payment>> GetByCustomerIdAsync(
            int customerId);

        Task<IEnumerable<Payment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<Payment>> GetByStatusAsync(
            string status);

        Task<Payment?> GetPaymentSettingsAsync();

        Task<IEnumerable<Payment>> GetByPaymentMethodAsync(
            string paymentMethod);

        Task<Payment?> GetByTransactionIdAsync(
            string transactionId);

        Task<IEnumerable<Payment>> SearchAsync(
            string? search);

        Task<PaymentStatistics> GetStatisticsAsync();

        Task<(IEnumerable<Payment> Items, int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<Payment>> GetSortedAsync(
            string? sort);


        // =========================================================
        // BANK DETAILS
        // =========================================================

        Task<BankDetailsDto?> GetBankDetailsAsync();

      

        Task<bool> UpdateBankDetailsAsync(
            BankDetailsDto bankDetails);


        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        Task<PaymentGatewayDto?> GetPaymentGatewayAsync();

      

        Task<bool> UpdatePaymentGatewayAsync(
            PaymentGatewayDto gateway);


        // =========================================================
        // UPI SETTINGS
        // =========================================================

        Task<UpiSettingsDto?> GetUpiSettingsAsync();
        Task<BankDetailsDto?> CreateBankDetailsAsync(
    BankDetailsDto bankDetails);

        Task<PaymentGatewayDto?> CreatePaymentGatewayAsync(
            PaymentGatewayDto gateway);

        Task<UpiSettingsDto?> CreateUpiSettingsAsync(
            UpiSettingsDto upiSettings);


        Task<bool> UpdateUpiSettingsAsync(
            UpiSettingsDto upiSettings);


        // =========================================================
        // PAYMENT CREATE
        // =========================================================

        Task AddAsync(
            Payment payment);


        // =========================================================
        // PAYMENT UPDATE
        // =========================================================

        Task UpdateAsync(
            Payment payment);


        // =========================================================
        // PAYMENT DELETE
        // =========================================================

        Task DeleteAsync(
            int paymentId);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}

