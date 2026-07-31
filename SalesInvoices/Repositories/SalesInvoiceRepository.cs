using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.Interfaces;

namespace Marketplacesellerportal.SalesInvoices.Repositories
{
    public class SalesInvoiceRepository : ISalesInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesInvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesInvoice>> GetAllAsync()
        {
            return await _context.SalesInvoices.ToListAsync();
        }

        public async Task<SalesInvoice?> GetByIdAsync(int salesInvoiceId)
        {
            return await _context.SalesInvoices
                .FirstOrDefaultAsync(x => x.SalesInvoiceId == salesInvoiceId);
        }

        public async Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _context.SalesInvoices
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesInvoice>> GetByStatusAsync(string status)
        {
            return await _context.SalesInvoices
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(string paymentStatus)
        {
            return await _context.SalesInvoices
                .Where(x => x.PaymentStatus == paymentStatus)
                .ToListAsync();
        }

        public async Task<SalesInvoice?> GetByInvoiceNumberAsync(string invoiceNumber)
        {
            return await _context.SalesInvoices
                .FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
        }

        public async Task AddAsync(SalesInvoice salesInvoice)
        {
            await _context.SalesInvoices.AddAsync(salesInvoice);
        }

        public Task UpdateAsync(SalesInvoice salesInvoice)
        {
            _context.SalesInvoices.Update(salesInvoice);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int salesInvoiceId)
        {
            var entity = await GetByIdAsync(salesInvoiceId);

            if (entity != null)
                _context.SalesInvoices.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
