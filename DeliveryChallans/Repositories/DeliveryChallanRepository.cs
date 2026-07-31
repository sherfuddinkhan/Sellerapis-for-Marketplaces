using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;

namespace Marketplacesellerportal.DeliveryChallans.Repositories
{
    public class DeliveryChallanRepository : IDeliveryChallanRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryChallanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeliveryChallan>> GetAllAsync()
        {
            return await _context.DeliveryChallans.ToListAsync();
        }

        public async Task<DeliveryChallan?> GetByIdAsync(int deliveryChallanId)
        {
            return await _context.DeliveryChallans
                .FirstOrDefaultAsync(x => x.DeliveryChallanId == deliveryChallanId);
        }

        public async Task<IEnumerable<DeliveryChallan>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _context.DeliveryChallans
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DeliveryChallan>> GetByStatusAsync(string status)
        {
            return await _context.DeliveryChallans
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<DeliveryChallan?> GetByChallanNumberAsync(string challanNumber)
        {
            return await _context.DeliveryChallans
                .FirstOrDefaultAsync(x => x.ChallanNumber == challanNumber);
        }

        public async Task AddAsync(DeliveryChallan deliveryChallan)
        {
            await _context.DeliveryChallans.AddAsync(deliveryChallan);
        }

        public Task UpdateAsync(DeliveryChallan deliveryChallan)
        {
            _context.DeliveryChallans.Update(deliveryChallan);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int deliveryChallanId)
        {
            var entity = await GetByIdAsync(deliveryChallanId);

            if (entity != null)
                _context.DeliveryChallans.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
