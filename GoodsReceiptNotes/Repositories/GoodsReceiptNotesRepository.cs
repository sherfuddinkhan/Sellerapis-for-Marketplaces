using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptNotes.DTOs;
using Marketplacesellerportal.GoodsReceiptNotes.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptNotes.Repositories
{
    public class GoodsReceiptNotesRepository : IGoodsReceiptNoteRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptNotesRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetAllAsync()
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<GoodsReceiptNote?>
            GetByIdAsync(
                int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptNoteId == goodsReceiptNoteId);
        }


        // =========================================================
        // GET BY PURCHASE ORDER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SUPPLIER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.SupplierId == supplierId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetByStatusAsync(
                string status)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .Where(x =>
                    x.Status == status)
                .ToListAsync();
        }


        // =========================================================
        // GET SPECIFIC PURCHASE ORDER + GRN
        // =========================================================

        public async Task<GoodsReceiptNote?>
            GetByPurchaseOrderAndGRNAsync(
                int purchaseOrderId,
                int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptNotes
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.GoodsReceiptNoteId == goodsReceiptNoteId);
        }


        // =========================================================
        // SEARCH
        //
        // /api/goods-receipt-notes?search=GRN-998
        // /api/goods-receipt-notes?status=inspected
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query = _context.GoodsReceiptNotes
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.GRNNumber != null &&
                     x.GRNNumber.Contains(search)) ||

                    (x.Status != null &&
                     x.Status.Contains(search)) ||

                    (x.Remarks != null &&
                     x.Remarks.Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();

                query = query.Where(x =>
                    x.Status == status);
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // STATISTICS
        //
        // /api/goods-receipt-notes/stats
        // =========================================================

        public async Task<GoodsReceiptNoteStatistics>
            GetStatisticsAsync()
        {
            var query = _context.GoodsReceiptNotes
                .AsNoTracking();

            var totalRecords =
                await query.CountAsync();

            var receivedCount =
                await query.CountAsync(x =>
                    x.Status == "received");

            var inspectedCount =
                await query.CountAsync(x =>
                    x.Status == "inspected");

            var rejectedCount =
                await query.CountAsync(x =>
                    x.Status == "rejected");

            var completedCount =
                await query.CountAsync(x =>
                    x.Status == "completed");

            var pendingCount =
                await query.CountAsync(x =>
                    x.Status == "pending");

            var totalAmount =
                await query
                    .SumAsync(x =>
                        (decimal?)x.TotalAmount) ?? 0;

            var totalQuantity =
                await query
                    .SumAsync(x =>
                        (decimal?)x.TotalQuantity) ?? 0;

            var receivedQuantity =
                await query
                    .SumAsync(x =>
                        (decimal?)x.ReceivedQuantity) ?? 0;

            var rejectedQuantity =
                await query
                    .SumAsync(x =>
                        (decimal?)x.RejectedQuantity) ?? 0;

            var distinctPurchaseOrders =
                await query
                    .Select(x => x.PurchaseOrderId)
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

            var distinctSuppliers =
                await query
                    .Where(x => x.SupplierId != null)
                    .Select(x => x.SupplierId)
                    .Distinct()
                    .CountAsync();

            return new GoodsReceiptNoteStatistics
            {
                TotalRecords = totalRecords,

                ReceivedCount = receivedCount,

                InspectedCount = inspectedCount,

                RejectedCount = rejectedCount,

                CompletedCount = completedCount,

                PendingCount = pendingCount,

                TotalAmount = totalAmount,

                TotalQuantity = totalQuantity,

                ReceivedQuantity = receivedQuantity,

                RejectedQuantity = rejectedQuantity,

                DistinctPurchaseOrders =
                    distinctPurchaseOrders,

                DistinctSellers =
                    distinctSellers,

                DistinctCustomers =
                    distinctCustomers,

                DistinctSuppliers =
                    distinctSuppliers
            };
        }


        // =========================================================
        // PAGINATION
        //
        // /api/goods-receipt-notes?page=1&limit=15
        // =========================================================

        public async Task<(
            IEnumerable<GoodsReceiptNote> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            if (limit > 100)
                limit = 100;

            var query = _context.GoodsReceiptNotes
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.GoodsReceiptNoteId)
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
        //
        // grn_asc
        // grn_desc
        // date_asc
        // date_desc
        // quantity_asc
        // quantity_desc
        // amount_asc
        // amount_desc
        // status_asc
        // status_desc
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptNote>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.GoodsReceiptNotes
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "grn_asc":

                    query = query
                        .OrderBy(x => x.GRNNumber);

                    break;

                case "grn_desc":

                    query = query
                        .OrderByDescending(x => x.GRNNumber);

                    break;

                case "date_asc":

                    query = query
                        .OrderBy(x => x.ReceiptDate);

                    break;

                case "date_desc":

                    query = query
                        .OrderByDescending(x => x.ReceiptDate);

                    break;

                case "quantity_asc":

                    query = query
                        .OrderBy(x => x.TotalQuantity);

                    break;

                case "quantity_desc":

                    query = query
                        .OrderByDescending(x => x.TotalQuantity);

                    break;

                case "amount_asc":

                    query = query
                        .OrderBy(x => x.TotalAmount);

                    break;

                case "amount_desc":

                    query = query
                        .OrderByDescending(x => x.TotalAmount);

                    break;

                case "status_asc":

                    query = query
                        .OrderBy(x => x.Status);

                    break;

                case "status_desc":

                    query = query
                        .OrderByDescending(x => x.Status);

                    break;

                default:

                    query = query
                        .OrderByDescending(x =>
                            x.GoodsReceiptNoteId);

                    break;
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            GoodsReceiptNote goodsReceiptNote)
        {
            await _context.GoodsReceiptNotes
                .AddAsync(goodsReceiptNote);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            GoodsReceiptNote goodsReceiptNote)
        {
            _context.GoodsReceiptNotes
                .Update(goodsReceiptNote);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int goodsReceiptNoteId)
        {
            var entity =
                await GetByIdAsync(
                    goodsReceiptNoteId);

            if (entity != null)
            {
                _context.GoodsReceiptNotes
                    .Remove(entity);
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