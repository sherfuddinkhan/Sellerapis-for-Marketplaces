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

        public async Task<IEnumerable<Payment>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Payment?>
            GetByIdAsync(
                int paymentId)
        {
            return await _repository.GetByIdAsync(
                paymentId);
        }

        // =========================================================
        // GET BY ORDER ID
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetByOrderIdAsync(
                int orderId)
        {
            return await _repository.GetByOrderIdAsync(
                orderId);
        }

        // =========================================================
        // GET BY SELLER ID
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER ID
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetByStatusAsync(
                string status)
        {
            return await _repository.GetByStatusAsync(
                status);
        }

        // =========================================================
        // GET BY PAYMENT METHOD
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetByPaymentMethodAsync(
                string paymentMethod)
        {
            return await _repository.GetByPaymentMethodAsync(
                paymentMethod);
        }

        // =========================================================
        // GET BY TRANSACTION ID
        // =========================================================

        public async Task<Payment?>
            GetByTransactionIdAsync(
                string transactionId)
        {
            return await _repository.GetByTransactionIdAsync(
                transactionId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<Payment>>
            SearchAsync(
                string? search)
        {
            return await _repository.SearchAsync(
                search);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<PaymentStatistics>
            GetStatisticsAsync()
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

        public async Task<IEnumerable<Payment>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // BANK DETAILS
        // =========================================================

        public async Task<BankDetailsDto?>
            GetBankDetailsAsync()
        {
            return await _repository.GetBankDetailsAsync();
        }

        public async Task<bool>
            UpdateBankDetailsAsync(
                BankDetailsDto bankDetails)
        {
            return await _repository.UpdateBankDetailsAsync(
                bankDetails);
        }

        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        public async Task<PaymentGatewayDto?>
            GetPaymentGatewayAsync()
        {
            return await _repository.GetPaymentGatewayAsync();
        }

        public async Task<bool>
            UpdatePaymentGatewayAsync(
                PaymentGatewayDto gateway)
        {
            return await _repository.UpdatePaymentGatewayAsync(
                gateway);
        }

        // =========================================================
        // UPI SETTINGS
        // =========================================================

        public async Task<UpiSettingsDto?>
            GetUpiSettingsAsync()
        {
            return await _repository.GetUpiSettingsAsync();
        }

        public async Task<bool>
            UpdateUpiSettingsAsync(
                UpiSettingsDto upiSettings)
        {
            return await _repository.UpdateUpiSettingsAsync(
                upiSettings);
        }

        // =========================================================
        // CREATE
        // =========================================================
       
      public async Task<Payment> CreateAsync(Payment payment)
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
        
public async Task<IEnumerable<Payment>>
    GetBySellerCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }


        public async Task<Payment?> GetPaymentSettingsAsync()
        {
            return await _repository.GetPaymentSettingsAsync();
        }
        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
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
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
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

