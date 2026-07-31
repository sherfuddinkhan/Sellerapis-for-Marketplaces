using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Payments.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync();

        Task<Payment?> GetByIdAsync(int paymentId);

        Task<IEnumerable<Payment>> GetByOrderAsync(int orderId);

        Task<IEnumerable<Payment>> GetByStatusAsync(string paymentStatus);

        Task<Payment?> GetByTransactionIdAsync(string transactionId);

        Task<Payment> CreateAsync(Payment payment);

        Task<bool> UpdateAsync(int paymentId, Payment payment);

        Task<bool> DeleteAsync(int paymentId);
    }
}
