using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplacesellerportal.Payments.Interfaces
{
    public interface IPaymentService
    {
        // =========================================================
        // PAYMENT
        // =========================================================

        Task<IEnumerable<Payment>>
            GetAllAsync();

        Task<Payment?>
            GetByIdAsync(
                int paymentId);

        Task<IEnumerable<Payment>>
            GetByOrderIdAsync(
                int orderId);

        Task<IEnumerable<Payment>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<Payment>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<Payment>>
            GetByCustomerIdAsync(
                int customerId);

        Task<Payment?>
            GetPaymentSettingsAsync();

        Task<IEnumerable<Payment>>
            GetByStatusAsync(
                string status);

        Task<IEnumerable<Payment>>
            GetByPaymentMethodAsync(
                string paymentMethod);

        Task<Payment?>
            GetByTransactionIdAsync(
                string transactionId);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<Payment>>
            SearchAsync(
                string? search);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<PaymentStatistics>
            GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<Payment> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<Payment>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // BANK DETAILS
        // =========================================================

        Task<BankDetailsDto?>
            GetBankDetailsAsync();

        // POST
        Task<BankDetailsDto?>
            CreateBankDetailsAsync(
                BankDetailsDto bankDetails);

        // PUT
        Task<bool>
            UpdateBankDetailsAsync(
                BankDetailsDto bankDetails);


        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        Task<PaymentGatewayDto?>
            GetPaymentGatewayAsync();

        // POST
        Task<PaymentGatewayDto?>
            CreatePaymentGatewayAsync(
                PaymentGatewayDto gateway);

        // PUT
        Task<bool>
            UpdatePaymentGatewayAsync(
                PaymentGatewayDto gateway);


        // =========================================================
        // UPI SETTINGS
        // =========================================================

        Task<UpiSettingsDto?>
            GetUpiSettingsAsync();

        // POST
        Task<UpiSettingsDto?>
            CreateUpiSettingsAsync(
                UpiSettingsDto upiSettings);

        // PUT
        Task<bool>
            UpdateUpiSettingsAsync(
                UpiSettingsDto upiSettings);


        // =========================================================
        // PAYMENT CREATE
        // =========================================================

        Task<Payment>
            CreateAsync(
                Payment payment);


        // =========================================================
        // PAYMENT UPDATE
        // =========================================================

        Task<bool>
            UpdateAsync(
                int paymentId,
                Payment payment);


        // =========================================================
        // PAYMENT DELETE
        // =========================================================

        Task<bool>
            DeleteAsync(
                int paymentId);
    }
}