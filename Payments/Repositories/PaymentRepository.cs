using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Payments.DTOs;
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

        // =========================================================
        // GET ALL PAYMENTS
        // =========================================================

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Payment?> GetByIdAsync(
            int paymentId)
        {
            return await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.PaymentId == paymentId);
        }

        public async Task<Payment?> GetPaymentSettingsAsync()
        {
            return await _context.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();
        }
        // =========================================================
        // GET BY ORDER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByOrderIdAsync(
            int orderId)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.OrderId == orderId)
                .ToListAsync();
        }
        
public async Task<IEnumerable<Payment>>
    GetBySellerCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY CUSTOMER ID
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<Payment>> GetByStatusAsync(
            string status)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.PaymentStatus != null &&
                    x.PaymentStatus == status)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PAYMENT METHOD
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetByPaymentMethodAsync(
                string paymentMethod)
        {
            return await _context.Payments
                .AsNoTracking()
                .Where(x =>
                    x.PaymentMethod != null &&
                    x.PaymentMethod == paymentMethod)
                .ToListAsync();
        }

        // =========================================================
        // GET BY TRANSACTION ID
        // =========================================================

        public async Task<Payment?> GetByTransactionIdAsync(
            string transactionId)
        {
            return await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.TransactionId == transactionId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<Payment>> SearchAsync(
            string? search)
        {
            var query = _context.Payments
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.PaymentMethod != null &&
                     x.PaymentMethod.Contains(search))

                    ||

                    (x.PaymentStatus != null &&
                     x.PaymentStatus.Contains(search))

                    ||

                    (x.TransactionId != null &&
                     x.TransactionId.Contains(search)));
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<PaymentStatistics>
            GetStatisticsAsync()
        {
            var query = _context.Payments
                .AsNoTracking();

            return new PaymentStatistics
            {
                TotalPayments =
                    await query.CountAsync(),

                TotalAmount =
                    await query.SumAsync(x =>
                        (decimal?)x.Amount) ?? 0,

                PendingPayments =
                    await query.CountAsync(x =>
                        x.PaymentStatus != null &&
                        x.PaymentStatus.ToLower() == "pending"),

                CompletedPayments =
                    await query.CountAsync(x =>
                        x.PaymentStatus != null &&
                        x.PaymentStatus.ToLower() == "completed"),

                FailedPayments =
                    await query.CountAsync(x =>
                        x.PaymentStatus != null &&
                        x.PaymentStatus.ToLower() == "failed"),

                CancelledPayments =
                    await query.CountAsync(x =>
                        x.PaymentStatus != null &&
                        x.PaymentStatus.ToLower() == "cancelled"),

                DistinctOrders =
                    await query
                        .Select(x => x.OrderId)
                        .Distinct()
                        .CountAsync(),

                DistinctSellers =
                    await query
                        .Select(x => x.SellerId)
                        .Distinct()
                        .CountAsync(),

                DistinctCustomers =
                    await query
                        .Select(x => x.CustomerId)
                        .Distinct()
                        .CountAsync(),

                DistinctPaymentMethods =
                    await query
                        .Where(x =>
                            x.PaymentMethod != null)
                        .Select(x =>
                            x.PaymentMethod)
                        .Distinct()
                        .CountAsync(),

                FirstPaymentDate =
                    await query
                        .Select(x =>
                            (DateTime?)x.PaymentDate)
                        .MinAsync(),

                LastPaymentDate =
                    await query
                        .Select(x =>
                            (DateTime?)x.PaymentDate)
                        .MaxAsync()
            };
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

            var query = _context.Payments
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.PaymentId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (items, totalCount);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<Payment>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.Payments
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "amount_asc":

                    query = query
                        .OrderBy(x => x.Amount);

                    break;

                case "amount_desc":

                    query = query
                        .OrderByDescending(x => x.Amount);

                    break;

                case "date_asc":

                    query = query
                        .OrderBy(x => x.PaymentDate);

                    break;

                case "date_desc":

                    query = query
                        .OrderByDescending(x => x.PaymentDate);

                    break;

                case "status_asc":

                    query = query
                        .OrderBy(x => x.PaymentStatus);

                    break;

                case "status_desc":

                    query = query
                        .OrderByDescending(x => x.PaymentStatus);

                    break;

                case "method_asc":

                    query = query
                        .OrderBy(x => x.PaymentMethod);

                    break;

                case "method_desc":

                    query = query
                        .OrderByDescending(x => x.PaymentMethod);

                    break;

                default:

                    query = query
                        .OrderByDescending(x =>
                            x.PaymentId);

                    break;
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // BANK DETAILS
        // =========================================================

        public async Task<BankDetailsDto?> GetBankDetailsAsync()
        {
            // TODO:
            // Implement after BankDetails storage/table is created.

            return await Task.FromResult<BankDetailsDto?>(
                null);
        }

        public async Task<bool> UpdateBankDetailsAsync(
            BankDetailsDto bankDetails)
        {
            // TODO:
            // Implement after BankDetails storage/table is created.

            return await Task.FromResult(false);
        }

        // =========================================================
        // PAYMENT GATEWAY
        // =========================================================

        public async Task<PaymentGatewayDto?>
            GetPaymentGatewayAsync()
        {
            // TODO:
            // Implement after PaymentGateway storage/table
            // is created.

            return await Task.FromResult<PaymentGatewayDto?>(
                null);
        }

        public async Task<bool> UpdatePaymentGatewayAsync(
            PaymentGatewayDto gateway)
        {
            // TODO:
            // Implement after PaymentGateway storage/table
            // is created.

            return await Task.FromResult(false);
        }

        // =========================================================
        // UPI SETTINGS
        // =========================================================

        public async Task<UpiSettingsDto?>
            GetUpiSettingsAsync()
        {
            // TODO:
            // Implement after UPI storage/table is created.

            return await Task.FromResult<UpiSettingsDto?>(
                null);
        }

        public async Task<bool> UpdateUpiSettingsAsync(
            UpiSettingsDto upiSettings)
        {
            // TODO:
            // Implement after UPI storage/table is created.

            return await Task.FromResult(false);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            Payment payment)
        {
            await _context.Payments
                .AddAsync(payment);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            Payment payment)
        {
            _context.Payments
                .Update(payment);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int paymentId)
        {
            var payment =
                await _context.Payments
                    .FirstOrDefaultAsync(x =>
                        x.PaymentId == paymentId);

            if (payment != null)
            {
                _context.Payments
                    .Remove(payment);
            }
        }

        // =========================================================
        // SAVE CHANGES
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

