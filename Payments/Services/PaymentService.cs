using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.Interfaces;

namespace Marketplacesellerportal.Payments.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Payment?> GetByIdAsync(int paymentId)
        {
            return await _repository.GetByIdAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetByOrderAsync(int orderId)
        {
            return await _repository.GetByOrderAsync(orderId);
        }

        public async Task<IEnumerable<Payment>> GetByStatusAsync(string paymentStatus)
        {
            return await _repository.GetByStatusAsync(paymentStatus);
        }

        public async Task<Payment?> GetByTransactionIdAsync(string transactionId)
        {
            return await _repository.GetByTransactionIdAsync(transactionId);
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            payment.CreatedDate = DateTime.Now;

            if (payment.PaymentDate == DateTime.MinValue)
                payment.PaymentDate = DateTime.Now;

            await _repository.AddAsync(payment);
            await _repository.SaveChangesAsync();

            return payment;
        }

        public async Task<bool> UpdateAsync(int paymentId, Payment payment)
        {
            var existing = await _repository.GetByIdAsync(paymentId);

            if (existing == null)
                return false;

            existing.OrderId = payment.OrderId;
            existing.PaymentMethod = payment.PaymentMethod;
            existing.Amount = payment.Amount;
            existing.PaymentDate = payment.PaymentDate;
            existing.TransactionId = payment.TransactionId;
            existing.PaymentStatus = payment.PaymentStatus;
            existing.Remarks = payment.Remarks;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int paymentId)
        {
            var existing = await _repository.GetByIdAsync(paymentId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(paymentId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
