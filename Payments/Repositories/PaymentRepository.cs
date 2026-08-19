using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.Interfaces;

namespace Marketplacesellerportal.Payments.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.Payments
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<Payment?> GetByIdAsync(int paymentId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(x => x.PaymentId == paymentId);
        }
        public async Task<IEnumerable<Payment>>
    GetBySellerCustomerAsync(int sellerId, int customerId)
        {
            return await _context.Payments
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetByOrderAsync(int orderId)
        {
            return await _context.Payments
                .Where(x => x.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByStatusAsync(string paymentStatus)
        {
            return await _context.Payments
                .Where(x => x.PaymentStatus == paymentStatus)
                .ToListAsync();
        }

        public async Task<Payment?> GetByTransactionIdAsync(string transactionId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(x => x.TransactionId == transactionId);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int paymentId)
        {
            var payment = await GetByIdAsync(paymentId);

            if (payment != null)
                _context.Payments.Remove(payment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
