using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.DTOs;
using Marketplacesellerportal.PurchaseOrders.Interfaces;

namespace Marketplacesellerportal.PurchaseOrders.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // GET: /api/purchase-orders
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _context.PurchaseOrders
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // GET: /api/purchase-orders/{id}
        // =========================================================

        public async Task<PurchaseOrder?> GetByIdAsync(
            int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.PurchaseOrders
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.PurchaseOrders
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SUPPLIER
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _context.PurchaseOrders
                .AsNoTracking()
                .Where(x =>
                    x.SupplierId == supplierId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER + PURCHASE ORDER
        // =========================================================

        public async Task<PurchaseOrder?>
            GetBySellerAndPurchaseOrderIdAsync(
                int sellerId,
                int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }


        // =========================================================
        // GET BY SELLER + SUPPLIER + PURCHASE ORDER
        // =========================================================

        public async Task<PurchaseOrder?>
            GetBySellerSupplierAndPurchaseOrderIdAsync(
                int sellerId,
                int supplierId,
                int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.SupplierId == supplierId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }


        // =========================================================
        // GET PURCHASE ORDER
        // SELLER + CUSTOMER + PURCHASE ORDER
        // =========================================================

        public async Task<PurchaseOrder?>
            GetPurchaseOrderAsync(
                int sellerId,
                int customerId,
                int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }


        // =========================================================
        // SEARCH
        // GET:
        // /api/purchase-orders?search=PO-5520
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>>
            SearchAsync(
                string? search)
        {
            var query = _context.PurchaseOrders
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.PurchaseOrderNumber != null &&
                    x.PurchaseOrderNumber.Contains(search));
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // STATISTICS
        // GET:
        // /api/purchase-orders/stats
        // =========================================================

        public async Task<PurchaseOrderStatistics>
            GetStatisticsAsync()
        {
            var query = _context.PurchaseOrders
                .AsNoTracking();

            var statistics = new PurchaseOrderStatistics
            {
                TotalOrders =
                    await query.CountAsync(),

                PendingApproval =
                    await query.CountAsync(x =>
                        x.Status != null &&
                        x.Status.ToLower() ==
                        "pending_approval"),

                ApprovedOrders =
                    await query.CountAsync(x =>
                        x.Status != null &&
                        x.Status.ToLower() ==
                        "approved"),

                RejectedOrders =
                    await query.CountAsync(x =>
                        x.Status != null &&
                        x.Status.ToLower() ==
                        "rejected"),

                CompletedOrders =
                    await query.CountAsync(x =>
                        x.Status != null &&
                        x.Status.ToLower() ==
                        "completed"),

                TotalAmount =
                    await query
                        .Select(x => (decimal?)x.TotalAmount)
                        .SumAsync() ?? 0
            };

            return statistics;
        }


        // =========================================================
        // PAGINATION
        // GET:
        // /api/purchase-orders?page=1&limit=10
        // =========================================================

        public async Task<(
            IEnumerable<PurchaseOrder> Items,
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

            var query = _context.PurchaseOrders
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.PurchaseOrderId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }


        // =========================================================
        // STATUS FILTER
        // GET:
        // /api/purchase-orders?status=pending_approval
        // =========================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetByStatusAsync(
                string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await _context.PurchaseOrders
                    .AsNoTracking()
                    .ToListAsync();
            }

            status = status.Trim();

            return await _context.PurchaseOrders
                .AsNoTracking()
                .Where(x =>
                    x.Status != null &&
                    x.Status.ToLower() ==
                    status.ToLower())
                .ToListAsync();
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            PurchaseOrder purchaseOrder)
        {
            await _context.PurchaseOrders
                .AddAsync(purchaseOrder);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders
                .Update(purchaseOrder);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int purchaseOrderId)
        {
            var po =
                await GetByIdAsync(purchaseOrderId);

            if (po != null)
            {
                _context.PurchaseOrders
                    .Remove(po);
            }
        }
        public async Task<IEnumerable<PurchaseOrder>> GetSortedAsync(
    string? sort)
        {
            var query = _context.PurchaseOrders
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "status_asc":

                    query = query
                        .OrderBy(x => x.Status);

                    break;

                case "status_desc":

                    query = query
                        .OrderByDescending(x => x.Status);

                    break;

                case "date_asc":

                    query = query
                        .OrderBy(x => x.OrderDate);

                    break;

                case "date_desc":

                    query = query
                        .OrderByDescending(x => x.OrderDate);

                    break;

                case "amount_asc":

                    query = query
                        .OrderBy(x => x.TotalAmount);

                    break;

                case "amount_desc":

                    query = query
                        .OrderByDescending(x => x.TotalAmount);

                    break;

                case "number_asc":

                    query = query
                        .OrderBy(x => x.PurchaseOrderNumber);

                    break;

                case "number_desc":

                    query = query
                        .OrderByDescending(x => x.PurchaseOrderNumber);

                    break;

                default:

                    query = query
                        .OrderByDescending(x =>
                            x.PurchaseOrderId);

                    break;
            }

            return await query.ToListAsync();
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