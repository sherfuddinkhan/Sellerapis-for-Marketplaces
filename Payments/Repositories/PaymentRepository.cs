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

        public async Task<Payment?> GetByIdAsync(int paymentId)
        {
            return await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.PaymentId == paymentId);
        }

        // =========================================================
        // GET PAYMENT SETTINGS
        // =========================================================

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

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Payment>> GetBySellerCustomerAsync(
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

        public async Task<IEnumerable<Payment>> GetByPaymentMethodAsync(
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

        public async Task<PaymentStatistics> GetStatisticsAsync()
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

        public async Task<IEnumerable<Payment>> GetSortedAsync(
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
        // BANK DETAILS - GET
        // GET: /api/settings/payment/bank
        // =========================================================

        public async Task<BankDetailsDto?> GetBankDetailsAsync()
        {
            var payment = await _context.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return null;

            return new BankDetailsDto
            {
                BankName = payment.BankName,
                AccountHolderName = payment.AccountHolderName,
                AccountNumber = payment.AccountNumber,
                IFSCCode = payment.IFSCCode,
                BranchName = payment.BranchName
            };
        }

        // =========================================================
        // BANK DETAILS - CREATE
        // POST: /api/settings/payment/bank
        // =========================================================

        public async Task<BankDetailsDto?> CreateBankDetailsAsync(
    BankDetailsDto bankDetails)
        {
            if (bankDetails == null)
                return null;

            try
            {
                var settings = await _context.PaymentSettings
                    .FirstOrDefaultAsync(x =>
                        x.SellerId == bankDetails.SellerId &&
                        x.CustomerId == bankDetails.CustomerId);

                if (settings == null)
                {
                    settings = new PaymentSettings
                    {
                        SellerId = bankDetails.SellerId,
                        CustomerId = bankDetails.CustomerId,

                        BankName = bankDetails.BankName,
                        AccountHolderName = bankDetails.AccountHolderName,
                        AccountNumber = bankDetails.AccountNumber,
                        IFSCCode = bankDetails.IFSCCode,
                        BranchName = bankDetails.BranchName,

                        UpdatedDate = DateTime.UtcNow
                    };

                    await _context.PaymentSettings.AddAsync(settings);
                }
                else
                {
                    settings.BankName = bankDetails.BankName;
                    settings.AccountHolderName = bankDetails.AccountHolderName;
                    settings.AccountNumber = bankDetails.AccountNumber;
                    settings.IFSCCode = bankDetails.IFSCCode;
                    settings.BranchName = bankDetails.BranchName;

                    settings.UpdatedDate = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return new BankDetailsDto
                {
                    SellerId = settings.SellerId,
                    CustomerId = settings.CustomerId,

                    BankName = settings.BankName,
                    AccountHolderName = settings.AccountHolderName,
                    AccountNumber = settings.AccountNumber,
                    IFSCCode = settings.IFSCCode,
                    BranchName = settings.BranchName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "==================================================");

                Console.WriteLine(
                    "CREATE BANK DETAILS ERROR");

                Console.WriteLine(
                    ex.ToString());

                Console.WriteLine(
                    "==================================================");

                throw;
            }
        }

        // =========================================================
        // BANK DETAILS - UPDATE
        // PUT: /api/settings/payment/bank
        // =========================================================

        public async Task<bool> UpdateBankDetailsAsync(
            BankDetailsDto bankDetails)
        {
            var payment = await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return false;

            payment.BankName =
                bankDetails.BankName;

            payment.AccountHolderName =
                bankDetails.AccountHolderName;

            payment.AccountNumber =
                bankDetails.AccountNumber;

            payment.IFSCCode =
                bankDetails.IFSCCode;

            payment.BranchName =
                bankDetails.BranchName;

            payment.UpdatedDate =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // PAYMENT GATEWAY - GET
        // GET: /api/settings/payment/gateway
        // =========================================================

        public async Task<PaymentGatewayDto?> GetPaymentGatewayAsync()
        {
            var payment = await _context.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return null;

            return new PaymentGatewayDto
            {
                GatewayName =
                    payment.GatewayName,

                GatewayMerchantId =
                    payment.GatewayMerchantId,

                GatewayKey =
                    payment.GatewayKey,

                GatewaySecret =
                    payment.GatewaySecret,

                GatewayEnabled =
                    payment.GatewayEnabled
            };
        }

        // =========================================================
        // PAYMENT GATEWAY - CREATE
        // POST: /api/settings/payment/gateway
        // =========================================================

        public async Task<PaymentGatewayDto?> CreatePaymentGatewayAsync(
            PaymentGatewayDto gateway)
        {
            var payment = await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return null;

            payment.GatewayName =
                gateway.GatewayName;

            payment.GatewayMerchantId =
                gateway.GatewayMerchantId;

            payment.GatewayKey =
                gateway.GatewayKey;

            payment.GatewaySecret =
                gateway.GatewaySecret;

            payment.GatewayEnabled =
                gateway.GatewayEnabled;

            payment.UpdatedDate =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new PaymentGatewayDto
            {
                GatewayName =
                    payment.GatewayName,

                GatewayMerchantId =
                    payment.GatewayMerchantId,

                GatewayKey =
                    payment.GatewayKey,

                GatewaySecret =
                    payment.GatewaySecret,

                GatewayEnabled =
                    payment.GatewayEnabled
            };
        }

        // =========================================================
        // PAYMENT GATEWAY - UPDATE
        // PUT: /api/settings/payment/gateway
        // =========================================================

        public async Task<bool> UpdatePaymentGatewayAsync(
            PaymentGatewayDto gateway)
        {
            var payment = await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return false;

            payment.GatewayName =
                gateway.GatewayName;

            payment.GatewayMerchantId =
                gateway.GatewayMerchantId;

            payment.GatewayKey =
                gateway.GatewayKey;

            payment.GatewaySecret =
                gateway.GatewaySecret;

            payment.GatewayEnabled =
                gateway.GatewayEnabled;

            payment.UpdatedDate =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // UPI SETTINGS - GET
        // GET: /api/settings/payment/upi
        // =========================================================

        public async Task<UpiSettingsDto?> GetUpiSettingsAsync()
        {
            var payment = await _context.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return null;

            return new UpiSettingsDto
            {
                UPIId =
                    payment.UPIId,

                UPIName =
                    payment.UPIName,

                UPIEnabled =
                    payment.UPIEnabled
            };
        }

        // =========================================================
        // UPI SETTINGS - CREATE
        // POST: /api/settings/payment/upi
        // =========================================================

        public async Task<UpiSettingsDto?> CreateUpiSettingsAsync(
            UpiSettingsDto upiSettings)
        {
            var payment = await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return null;

            payment.UPIId =
                upiSettings.UPIId;

            payment.UPIName =
                upiSettings.UPIName;

            payment.UPIEnabled =
                upiSettings.UPIEnabled;

            payment.UpdatedDate =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new UpiSettingsDto
            {
                UPIId =
                    payment.UPIId,

                UPIName =
                    payment.UPIName,

                UPIEnabled =
                    payment.UPIEnabled
            };
        }

        // =========================================================
        // UPI SETTINGS - UPDATE
        // PUT: /api/settings/payment/upi
        // =========================================================

        public async Task<bool> UpdateUpiSettingsAsync(
            UpiSettingsDto upiSettings)
        {
            var payment = await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefaultAsync();

            if (payment == null)
                return false;

            payment.UPIId =
                upiSettings.UPIId;

            payment.UPIName =
                upiSettings.UPIName;

            payment.UPIEnabled =
                upiSettings.UPIEnabled;

            payment.UpdatedDate =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // PAYMENT CREATE
        // =========================================================

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments
                .AddAsync(payment);
        }

        // =========================================================
        // PAYMENT UPDATE
        // =========================================================

        public Task UpdateAsync(Payment payment)
        {
            _context.Payments
                .Update(payment);

            return Task.CompletedTask;
        }

        // =========================================================
        // PAYMENT DELETE
        // =========================================================

        public async Task DeleteAsync(int paymentId)
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