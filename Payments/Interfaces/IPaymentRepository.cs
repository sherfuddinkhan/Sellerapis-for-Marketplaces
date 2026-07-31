using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Payments.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();

        Task<Payment?> GetByIdAsync(int paymentId);

        Task<IEnumerable<Payment>> GetByOrderAsync(int orderId);

        Task<IEnumerable<Payment>> GetByStatusAsync(string paymentStatus);

        Task<Payment?> GetByTransactionIdAsync(string transactionId);

        Task AddAsync(Payment payment);

        Task UpdateAsync(Payment payment);

        Task DeleteAsync(int paymentId);

        Task SaveChangesAsync();
    }
}
