using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.Interfaces;

namespace Marketplacesellerportal.Shipments.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments.ToListAsync();
        }
        public async Task<IEnumerable<Shipment>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.Shipments
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<Shipment?> GetByIdAsync(int shipmentId)
        {
            return await _context.Shipments
                .FirstOrDefaultAsync(x => x.ShipmentId == shipmentId);
        }

        public async Task<IEnumerable<Shipment>> GetByOrderAsync(int orderId)
        {
            return await _context.Shipments
                .Where(x => x.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> GetByStatusAsync(string shipmentStatus)
        {
            return await _context.Shipments
                .Where(x => x.ShipmentStatus == shipmentStatus)
                .ToListAsync();
        }

        public async Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber)
        {
            return await _context.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);
        }

        public async Task AddAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
        }

        public Task UpdateAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int shipmentId)
        {
            var entity = await GetByIdAsync(shipmentId);

            if (entity != null)
                _context.Shipments.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
