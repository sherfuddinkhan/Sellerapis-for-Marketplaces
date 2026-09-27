using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.Interfaces;

namespace Marketplacesellerportal.SalesInvoices.Repositories
{
    public class SalesInvoiceRepository : ISalesInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesInvoiceRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetAllAsync()
        {
            return await _context.SalesInvoices

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .ToListAsync();
        }
        public async Task<IEnumerable<SalesInvoice>>
    GetBySellerAndCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _context.SalesInvoices
                .AsNoTracking()
                .Where(invoice =>
                    invoice.SellerId == sellerId &&
                    invoice.CustomerId == customerId)
                .OrderByDescending(invoice =>
                    invoice.SalesInvoiceId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<SalesInvoice?> GetByIdAsync(
            int salesInvoiceId)
        {
            return await _context.SalesInvoices

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .FirstOrDefaultAsync(
                    x => x.SalesInvoiceId == salesInvoiceId);
        }

        // =========================================================
        // GET BY SALES ORDER
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(
            int salesOrderId)
        {
            return await _context.SalesInvoices

                .Where(x =>
                    x.SalesOrderId == salesOrderId)

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .ToListAsync();
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByStatusAsync(
            string status)
        {
            return await _context.SalesInvoices

                .Where(x =>
                    x.Status == status)

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .ToListAsync();
        }

        // =========================================================
        // GET BY PAYMENT STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(
            string paymentStatus)
        {
            return await _context.SalesInvoices

                .Where(x =>
                    x.PaymentStatus == paymentStatus)

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.SalesInvoices

                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .ToListAsync();
        }

        // =========================================================
        // GET BY INVOICE NUMBER
        // =========================================================

        public async Task<SalesInvoice?> GetByInvoiceNumberAsync(
            string invoiceNumber)
        {
            return await _context.SalesInvoices

                .Include(x => x.Items)

                .Include(x => x.Payments)

                .Include(x => x.AdditionalCharges)

                .FirstOrDefaultAsync(
                    x => x.InvoiceNumber == invoiceNumber);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            SalesInvoice salesInvoice)
        {
            await _context.SalesInvoices.AddAsync(
                salesInvoice);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            SalesInvoice salesInvoice)
        {
            _context.SalesInvoices.Update(
                salesInvoice);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE INVOICE
        // =========================================================

        public async Task DeleteAsync(
            int salesInvoiceId)
        {
            var entity = await GetByIdAsync(
                salesInvoiceId);

            if (entity != null)
            {
                _context.SalesInvoices.Remove(
                    entity);
            }
        }

        // =========================================================
        // DELETE ITEMS
        // =========================================================

        public async Task DeleteItemsAsync(
            int salesInvoiceId)
        {
            var items = await _context.SalesInvoiceItems

                .Where(x =>
                    x.SalesInvoiceId == salesInvoiceId)

                .ToListAsync();

            if (items.Count > 0)
            {
                _context.SalesInvoiceItems.RemoveRange(
                    items);
            }
        }

        // =========================================================
        // DELETE PAYMENTS
        // =========================================================

        public async Task DeletePaymentsAsync(
            int salesInvoiceId)
        {
            var payments = await _context.SalesInvoicePayments

                .Where(x =>
                    x.SalesInvoiceId == salesInvoiceId)

                .ToListAsync();

            if (payments.Count > 0)
            {
                _context.SalesInvoicePayments.RemoveRange(
                    payments);
            }
        }

        // =========================================================
        // DELETE ADDITIONAL CHARGES
        // =========================================================

        public async Task DeleteAdditionalChargesAsync(
            int salesInvoiceId)
        {
            var charges =
                await _context.SalesInvoiceAdditionalCharges

                .Where(x =>
                    x.SalesInvoiceId == salesInvoiceId)

                .ToListAsync();

            if (charges.Count > 0)
            {
                _context.SalesInvoiceAdditionalCharges.RemoveRange(
                    charges);
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