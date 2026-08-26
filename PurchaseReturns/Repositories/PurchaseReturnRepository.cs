using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.DTOs;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Repositories
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseReturnRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetAllAsync()
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .OrderByDescending(x => x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<PurchaseReturn?>
            GetByIdAsync(
                int purchaseReturnId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.PurchaseReturnId == purchaseReturnId);
        }
        // =========================================================
        // GET BY SELLER
        // GET /api/purchase-returns/seller/{sellerId}
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CUSTOMER
        // GET /api/purchase-returns/customer/{customerId}
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }
        // =========================================================
        // GET BY PURCHASE ORDER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.PurchaseOrderId == purchaseOrderId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SUPPLIER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.SupplierId == supplierId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY GOODS RECEIPT NOTE
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.GoodsReceiptNoteId == goodsReceiptNoteId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByStatusAsync(
                string status)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .Where(x =>
                    x.Status == status)
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // GET SPECIFIC PURCHASE RETURN
        // =========================================================

        public async Task<PurchaseReturn?>
            GetPurchaseReturnAsync(
                int purchaseOrderId,
                int supplierId,
                int purchaseReturnId)
        {
            return await _context.PurchaseReturns
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.SupplierId == supplierId &&
                    x.PurchaseReturnId == purchaseReturnId);
        }

        // =========================================================
        // SEARCH + STATUS
        //
        // /api/purchase-returns?search=3120
        // /api/purchase-returns?status=pending_pickup
        // /api/purchase-returns?search=3120&status=pending_pickup
        //
        // Searches numeric IDs and status.
        // No ReturnNumber property is assumed.
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query = _context.PurchaseReturns
                .AsNoTracking()
                .AsQueryable();

            // =====================================================
            // SEARCH
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                if (int.TryParse(search, out int searchId))
                {
                    query = query.Where(x =>
                        x.PurchaseReturnId == searchId ||
                        x.PurchaseOrderId == searchId ||
                        x.SupplierId == searchId ||
                        x.GoodsReceiptNoteId == searchId ||
                        x.Status.Contains(search));
                }
                else
                {
                    query = query.Where(x =>
                        x.Status != null &&
                        x.Status.Contains(search));
                }
            }

            // =====================================================
            // STATUS FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();

                query = query.Where(x =>
                    x.Status == status);
            }

            return await query
                .OrderByDescending(x =>
                    x.PurchaseReturnId)
                .ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<PurchaseReturnStatistics>
            GetStatisticsAsync()
        {
            var query = _context.PurchaseReturns
                .AsNoTracking();

            var totalRecords =
                await query.CountAsync();

            var pendingPickupCount =
                await query.CountAsync(x =>
                    x.Status == "pending_pickup");

            var pickedUpCount =
                await query.CountAsync(x =>
                    x.Status == "picked_up");

            var receivedCount =
                await query.CountAsync(x =>
                    x.Status == "received");

            var approvedCount =
                await query.CountAsync(x =>
                    x.Status == "approved");

            var rejectedCount =
                await query.CountAsync(x =>
                    x.Status == "rejected");

            var cancelledCount =
                await query.CountAsync(x =>
                    x.Status == "cancelled");

            var completedCount =
                await query.CountAsync(x =>
                    x.Status == "completed");

            var distinctPurchaseOrders =
                await query
                    .Select(x => x.PurchaseOrderId)
                    .Distinct()
                    .CountAsync();

            var distinctSuppliers =
                await query
                    .Select(x => x.SupplierId)
                    .Distinct()
                    .CountAsync();

            var distinctSellers =
                await query
                    .Select(x => x.SellerId)
                    .Distinct()
                    .CountAsync();

            var distinctCustomers =
                await query
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .CountAsync();

            return new PurchaseReturnStatistics
            {
                TotalRecords =
                    totalRecords,

                PendingPickupCount =
                    pendingPickupCount,

                PickedUpCount =
                    pickedUpCount,

                ReceivedCount =
                    receivedCount,

                ApprovedCount =
                    approvedCount,

                RejectedCount =
                    rejectedCount,

                CancelledCount =
                    cancelledCount,

                CompletedCount =
                    completedCount,

                DistinctPurchaseOrders =
                    distinctPurchaseOrders,

                DistinctSuppliers =
                    distinctSuppliers,

                DistinctSellers =
                    distinctSellers,

                DistinctCustomers =
                    distinctCustomers
            };
        }

        // =========================================================
        // PAGINATION
        //
        // /api/purchase-returns?page=1&limit=10
        // =========================================================

        public async Task<(
            IEnumerable<PurchaseReturn> Items,
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

            var query = _context.PurchaseReturns
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.PurchaseReturnId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.PurchaseReturns
                .AsNoTracking()
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "id_asc" =>
                    await query
                        .OrderBy(x =>
                            x.PurchaseReturnId)
                        .ToListAsync(),

                "id_desc" =>
                    await query
                        .OrderByDescending(x =>
                            x.PurchaseReturnId)
                        .ToListAsync(),

                "status_asc" =>
                    await query
                        .OrderBy(x =>
                            x.Status)
                        .ToListAsync(),

                "status_desc" =>
                    await query
                        .OrderByDescending(x =>
                            x.Status)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderByDescending(x =>
                            x.PurchaseReturnId)
                        .ToListAsync()
            };
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            PurchaseReturn purchaseReturn)
        {
            await _context.PurchaseReturns
                .AddAsync(purchaseReturn);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            PurchaseReturn purchaseReturn)
        {
            _context.PurchaseReturns
                .Update(purchaseReturn);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int purchaseReturnId)
        {
            var entity =
                await _context.PurchaseReturns
                    .FirstOrDefaultAsync(x =>
                        x.PurchaseReturnId ==
                        purchaseReturnId);

            if (entity != null)
            {
                _context.PurchaseReturns
                    .Remove(entity);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

