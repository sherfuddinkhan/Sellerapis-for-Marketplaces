using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.DeliveryChallans.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.DeliveryChallans.Repositories
{
    public class DeliveryChallanRepository : IDeliveryChallanRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryChallanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>> GetAllAsync()
        {
            return await _context.DeliveryChallans
                .AsNoTracking()
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<DeliveryChallan?> GetByIdAsync(int id)
        {
            return await _context.DeliveryChallans
                .FirstOrDefaultAsync(
                    x => x.DeliveryChallanId == id);
        }

        // =====================================================
        // GET BY SALES ORDER
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetBySalesOrderAsync(int salesOrderId)
        {
            return await _context.DeliveryChallans
                .AsNoTracking()
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY STATUS
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetByStatusAsync(string status)
        {
            return await _context.DeliveryChallans
                .AsNoTracking()
                .Where(x => x.Status == status)
                .ToListAsync();
        }
        
// =====================================================
// GET BY SELLER + CUSTOMER
// =====================================================

public async Task<IEnumerable<DeliveryChallan>>
    GetBySellerCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _context.DeliveryChallans
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =====================================================
        // GET BY CHALLAN NUMBER
        // =====================================================

        public async Task<DeliveryChallan?>
            GetByChallanNumberAsync(string challanNumber)
        {
            return await _context.DeliveryChallans
                .FirstOrDefaultAsync(
                    x => x.ChallanNumber == challanNumber);
        }

        // =====================================================
        // SEARCH
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await GetAllAsync();
            }

            search = search.Trim();

            return await _context.DeliveryChallans
                .AsNoTracking()
                .Where(x =>
                    x.ChallanNumber.Contains(search) ||
                    x.Status.Contains(search) ||
                    x.VehicleNumber.Contains(search) ||
                    x.DriverName.Contains(search) ||
                    x.TransporterName.Contains(search))
                .ToListAsync();
        }

        // =====================================================
        // SORT
        // =====================================================

        public async Task<IEnumerable<DeliveryChallan>>
            GetSortedAsync(string? sort)
        {
            var query = _context.DeliveryChallans
                .AsNoTracking()
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query
                    .OrderByDescending(
                        x => x.DeliveryChallanId)
                    .ToListAsync();
            }

            switch (sort.ToLower())
            {
                case "id":
                case "deliverychallanid":
                    query = query.OrderBy(
                        x => x.DeliveryChallanId);
                    break;

                case "challannumber":
                case "challan_number":
                    query = query.OrderBy(
                        x => x.ChallanNumber);
                    break;

                case "challandate":
                case "challan_date":
                    query = query.OrderBy(
                        x => x.ChallanDate);
                    break;

                case "status":
                    query = query.OrderBy(
                        x => x.Status);
                    break;

                case "vehiclenumber":
                case "vehicle_number":
                    query = query.OrderBy(
                        x => x.VehicleNumber);
                    break;

                case "drivername":
                case "driver_name":
                    query = query.OrderBy(
                        x => x.DriverName);
                    break;

                case "transportername":
                case "transporter_name":
                    query = query.OrderBy(
                        x => x.TransporterName);
                    break;

                default:
                    query = query.OrderByDescending(
                        x => x.DeliveryChallanId);
                    break;
            }

            return await query.ToListAsync();
        }

        // =====================================================
        // PAGINATION
        // =====================================================

        public async Task<PagedResult<DeliveryChallan>>
            GetPagedAsync(int page, int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.DeliveryChallans
                .AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(
                    x => x.DeliveryChallanId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<DeliveryChallan>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }

        // =====================================================
        // STATISTICS
        // =====================================================

        public async Task<DeliveryChallanStatistics>
            GetStatisticsAsync()
        {
            var query = _context.DeliveryChallans
                .AsNoTracking();

            var totalCount = await query.CountAsync();

            var pendingCount = await query.CountAsync(
                x => x.Status == "Pending");

            var deliveredCount = await query.CountAsync(
                x => x.Status == "Delivered");

            var cancelledCount = await query.CountAsync(
                x => x.Status == "Cancelled");

            var inTransitCount = await query.CountAsync(
                x => x.Status == "In Transit");

            return new DeliveryChallanStatistics
            {
                TotalCount = totalCount,
                PendingCount = pendingCount,
                DeliveredCount = deliveredCount,
                CancelledCount = cancelledCount,
                InTransitCount = inTransitCount
            };
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task AddAsync(
            DeliveryChallan deliveryChallan)
        {
            await _context.DeliveryChallans.AddAsync(
                deliveryChallan);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public Task UpdateAsync(
            DeliveryChallan deliveryChallan)
        {
            _context.DeliveryChallans.Update(
                deliveryChallan);

            return Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task DeleteAsync(int id)
        {
            var deliveryChallan =
                await _context.DeliveryChallans
                    .FirstOrDefaultAsync(
                        x => x.DeliveryChallanId == id);

            if (deliveryChallan != null)
            {
                _context.DeliveryChallans.Remove(
                    deliveryChallan);
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

