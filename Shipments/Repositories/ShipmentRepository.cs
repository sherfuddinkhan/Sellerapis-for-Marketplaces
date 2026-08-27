using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Shipments.DTOs;
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

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<Shipment?> GetByIdAsync(
            int shipmentId)
        {
            return await _context.Shipments
                .FirstOrDefaultAsync(x =>
                    x.ShipmentId == shipmentId);
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        public async Task<IEnumerable<Shipment>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.Shipments
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY ORDER
        // =====================================================

        public async Task<IEnumerable<Shipment>>
            GetByOrderAsync(int orderId)
        {
            return await _context.Shipments
                .Where(x => x.OrderId == orderId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY STATUS
        // =====================================================

        public async Task<IEnumerable<Shipment>>
            GetByStatusAsync(string shipmentStatus)
        {
            return await _context.Shipments
                .Where(x =>
                    x.ShipmentStatus == shipmentStatus)
                .ToListAsync();
        }

        // =====================================================
        // GET BY TRACKING NUMBER
        // =====================================================

        public async Task<Shipment?>
            GetByTrackingNumberAsync(
                string trackingNumber)
        {
            return await _context.Shipments
                .FirstOrDefaultAsync(x =>
                    x.TrackingNumber == trackingNumber);
        }

        // =====================================================
        // SEARCH
        // GET:
        // /api/Shipment/search?search=ABC
        // =====================================================

        public async Task<IEnumerable<Shipment>>
            SearchAsync(string search)
        {
            search = search.Trim();

            return await _context.Shipments
                .Where(x =>
                    x.ShipmentId
                        .ToString()
                        .Contains(search) ||

                    x.SellerId
                        .ToString()
                        .Contains(search) ||

                    x.CustomerId
                        .ToString()
                        .Contains(search) ||

                    x.OrderId
                        .ToString()
                        .Contains(search) ||

                    (x.TrackingNumber != null &&
                     x.TrackingNumber.Contains(search)) ||

                    (x.ShipmentStatus != null &&
                     x.ShipmentStatus.Contains(search)))
                .ToListAsync();
        }

        // =====================================================
        // SORT
        // GET:
        // /api/Shipment/sort?sort=id_asc
        // =====================================================

        public async Task<IEnumerable<Shipment>>
            GetSortedAsync(string? sort)
        {
            var query = _context.Shipments
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "id_asc" =>
                    await query
                        .OrderBy(x => x.ShipmentId)
                        .ToListAsync(),

                "id_desc" =>
                    await query
                        .OrderByDescending(x => x.ShipmentId)
                        .ToListAsync(),

                "seller_asc" =>
                    await query
                        .OrderBy(x => x.SellerId)
                        .ToListAsync(),

                "seller_desc" =>
                    await query
                        .OrderByDescending(x => x.SellerId)
                        .ToListAsync(),

                "customer_asc" =>
                    await query
                        .OrderBy(x => x.CustomerId)
                        .ToListAsync(),

                "customer_desc" =>
                    await query
                        .OrderByDescending(x => x.CustomerId)
                        .ToListAsync(),

                "order_asc" =>
                    await query
                        .OrderBy(x => x.OrderId)
                        .ToListAsync(),

                "order_desc" =>
                    await query
                        .OrderByDescending(x => x.OrderId)
                        .ToListAsync(),

                "status_asc" =>
                    await query
                        .OrderBy(x => x.ShipmentStatus)
                        .ToListAsync(),

                "status_desc" =>
                    await query
                        .OrderByDescending(x => x.ShipmentStatus)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderBy(x => x.ShipmentId)
                        .ToListAsync()
            };
        }

        // =====================================================
        // PAGINATION
        // GET:
        // /api/Shipment/page?page=1&limit=15
        // =====================================================

        public async Task<PagedResult<Shipment>>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.Shipments
                .AsQueryable();

            var totalCount =
                await query.CountAsync();

            var items = await query
                .OrderBy(x => x.ShipmentId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<Shipment>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }

        // =====================================================
        // STATISTICS
        // GET:
        // /api/Shipment/statistics
        // =====================================================

        public async Task<ShipmentStatistics>
            GetStatisticsAsync()
        {
            var total =
                await _context.Shipments
                    .CountAsync();

            var delivered =
                await _context.Shipments
                    .CountAsync(x =>
                        x.ShipmentStatus == "Delivered");

            var pending =
                await _context.Shipments
                    .CountAsync(x =>
                        x.ShipmentStatus == "Pending");

            var cancelled =
                await _context.Shipments
                    .CountAsync(x =>
                        x.ShipmentStatus == "Cancelled");

            var inTransit =
                await _context.Shipments
                    .CountAsync(x =>
                        x.ShipmentStatus == "In Transit");

            return new ShipmentStatistics
            {
                TotalShipments = total,
                DeliveredShipments = delivered,
                PendingShipments = pending,
                CancelledShipments = cancelled,
                InTransitShipments = inTransit
            };
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task AddAsync(
            Shipment shipment)
        {
            await _context.Shipments
                .AddAsync(shipment);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public Task UpdateAsync(
            Shipment shipment)
        {
            _context.Shipments
                .Update(shipment);

            return Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task DeleteAsync(
            int shipmentId)
        {
            var entity =
                await GetByIdAsync(shipmentId);

            if (entity != null)
            {
                _context.Shipments
                    .Remove(entity);
            }
        }

        // =====================================================
        // SAVE CHANGES
        // =====================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}