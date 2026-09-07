using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.DTOs;
using Marketplacesellerportal.Payments.Interfaces;

namespace Marketplacesellerportal.Payments.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(
            IPaymentRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Payment?> GetByIdAsync(
            int paymentId)
        {
            return await _repository.GetByIdAsync(
                paymentId);
        }

        // =========================================================
        // GET BY ORDER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByOrderIdAsync(
            int orderId)
        {
            return await _repository.GetByOrderIdAsync(
                orderId);
        }

        // =========================================================
        // GET BY SELLER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Payment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByStatusAsync(
            string status)
        {
            return await _repository.GetByStatusAsync(
                status);
        }

        // =========================================================
        // GET BY PAYMENT METHOD
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByPaymentMethodAsync(
            string paymentMethod)
        {
            return await _repository.GetByPaymentMethodAsync(
                paymentMethod);
        }

        // =========================================================
        // GET BY TRANSACTION ID
        // =========================================================

        public async Task<Payment?> GetByTransactionIdAsync(
            string transactionId)
        {
            return await _repository.GetByTransactionIdAsync(
                transactionId);
        }

        // =========================================================
        // GET PAYMENT SETTINGS
        // =========================================================

        public async Task<Payment?> GetPaymentSettingsAsync()
        {
            return await _repository.GetPaymentSettingsAsync();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<Payment>> SearchAsync(
            string? search)
        {
            return await _repository.SearchAsync(
                search);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<PaymentStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<Payment> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<Payment>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // BANK DETAILS
        // =========================================================

        public async Task<BankDetailsDto?> GetBankDetailsAsync()
        {
            return await _repository.GetBankDetailsAsync();
        }

        // =========================================================
        // CREATE BANK DETAILS
        // POST
        // =========================================================

        public async Task<BankDetailsDto?> CreateBankDetailsAsync(
            BankDetailsDto bankDetails)
        {
            if (bankDetails == null)
                return null;

            return await _repository.CreateBankDetailsAsync(
                bankDetails);
        }

        // =========================================================
        // UPDATE BANK DETAILS
        // PUT
        // =========================================================

        public async Task<bool> UpdateBankDetailsAsync(
            BankDetailsDto bankDetails)
        {
            if (bankDetails == null)
                return false;

            return await _repository.UpdateBankDetailsAsync(
                bankDetails);
        }

        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        public async Task<PaymentGatewayDto?> GetPaymentGatewayAsync()
        {
            return await _repository.GetPaymentGatewayAsync();
        }

        // =========================================================
        // CREATE PAYMENT GATEWAY
        // POST
        // =========================================================

        public async Task<PaymentGatewayDto?> CreatePaymentGatewayAsync(
            PaymentGatewayDto gateway)
        {
            if (gateway == null)
                return null;

            return await _repository.CreatePaymentGatewayAsync(
                gateway);
        }

        // =========================================================
        // UPDATE PAYMENT GATEWAY
        // PUT
        // =========================================================

        public async Task<bool> UpdatePaymentGatewayAsync(
            PaymentGatewayDto gateway)
        {
            if (gateway == null)
                return false;

            return await _repository.UpdatePaymentGatewayAsync(
                gateway);
        }

        // =========================================================
        // UPI SETTINGS
        // =========================================================

        public async Task<UpiSettingsDto?> GetUpiSettingsAsync()
        {
            return await _repository.GetUpiSettingsAsync();
        }

        // =========================================================
        // CREATE UPI SETTINGS
        // POST
        // =========================================================

        public async Task<UpiSettingsDto?> CreateUpiSettingsAsync(
            UpiSettingsDto upiSettings)
        {
            if (upiSettings == null)
                return null;

            return await _repository.CreateUpiSettingsAsync(
                upiSettings);
        }

        // =========================================================
        // UPDATE UPI SETTINGS
        // PUT
        // =========================================================

        public async Task<bool> UpdateUpiSettingsAsync(
            UpiSettingsDto upiSettings)
        {
            if (upiSettings == null)
                return false;

            return await _repository.UpdateUpiSettingsAsync(
                upiSettings);
        }

        // =========================================================
        // CREATE PAYMENT
        // =========================================================

        public async Task<Payment> CreateAsync(
            Payment payment)
        {
            if (payment.PaymentDate == null ||
                payment.PaymentDate == DateTime.MinValue)
            {
                payment.PaymentDate = DateTime.Now;
            }

            await _repository.AddAsync(payment);

            await _repository.SaveChangesAsync();

            return payment;
        }

        // =========================================================
        // UPDATE PAYMENT
        // =========================================================

        public async Task<bool> UpdateAsync(
            int paymentId,
            Payment payment)
        {
            var existing =
                await _repository.GetByIdAsync(
                    paymentId);

            if (existing == null)
                return false;

            existing.OrderId =
                payment.OrderId;

            existing.PaymentMethod =
                payment.PaymentMethod;

            existing.Amount =
                payment.Amount;

            existing.PaymentStatus =
                payment.PaymentStatus;

            existing.TransactionId =
                payment.TransactionId;

            existing.PaymentDate =
                payment.PaymentDate;

            existing.SellerId =
                payment.SellerId;

            existing.CustomerId =
                payment.CustomerId;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE PAYMENT
        // =========================================================

        public async Task<bool> DeleteAsync(
            int paymentId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    paymentId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                paymentId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}