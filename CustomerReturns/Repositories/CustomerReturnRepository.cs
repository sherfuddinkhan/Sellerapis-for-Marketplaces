using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.CustomerReturns.Interfaces;

namespace Marketplacesellerportal.CustomerReturns.Repositories
{
    public class CustomerReturnRepository : ICustomerReturnRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerReturnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerReturn>> GetAllAsync()
        {
            return await _context.CustomerReturns.ToListAsync();
        }

        public async Task<CustomerReturn?> GetByIdAsync(int customerReturnId)
        {
            return await _context.CustomerReturns
                .FirstOrDefaultAsync(x => x.CustomerReturnId == customerReturnId);
        }

        public async Task<IEnumerable<CustomerReturn>> GetBySalesInvoiceAsync(int salesInvoiceId)
        {
            return await _context.CustomerReturns
                .Where(x => x.SalesInvoiceId == salesInvoiceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerReturn>> GetByProductAsync(int productId)
        {
            return await _context.CustomerReturns
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerReturn>> GetByStatusAsync(string status)
        {
            return await _context.CustomerReturns
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<CustomerReturn?> GetByReturnNumberAsync(string returnNumber)
        {
            return await _context.CustomerReturns
                .FirstOrDefaultAsync(x => x.ReturnNumber == returnNumber);
        }

        public async Task AddAsync(CustomerReturn customerReturn)
        {
            await _context.CustomerReturns.AddAsync(customerReturn);
        }

        public Task UpdateAsync(CustomerReturn customerReturn)
        {
            _context.CustomerReturns.Update(customerReturn);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int customerReturnId)
        {
            var entity = await GetByIdAsync(customerReturnId);

            if (entity != null)
                _context.CustomerReturns.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}