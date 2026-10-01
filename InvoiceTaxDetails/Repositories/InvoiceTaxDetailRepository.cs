using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Repositories
{
    public class InvoiceTaxDetailRepository
        : IInvoiceTaxDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTaxDetailRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceTaxDetail>> GetAllAsync()
            => await _context.InvoiceTaxDetails.ToListAsync();

        public async Task<InvoiceTaxDetail?> GetByIdAsync(int id)
            => await _context.InvoiceTaxDetails.FindAsync(id);

        public async Task<InvoiceTaxDetail> CreateAsync(
            InvoiceTaxDetail entity)
        {
            _context.InvoiceTaxDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(
            InvoiceTaxDetail entity)
        {
            _context.InvoiceTaxDetails.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity =
                await _context.InvoiceTaxDetails.FindAsync(id);

            if (entity == null)
                return false;

            _context.InvoiceTaxDetails.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}