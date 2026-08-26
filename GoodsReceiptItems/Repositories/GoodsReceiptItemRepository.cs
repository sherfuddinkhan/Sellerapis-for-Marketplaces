using Marketplacesellerportal.Database;
using Marketplacesellerportal.GoodsReceiptItems.DTOs;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.GoodsReceiptItems.Repositories
{
    public class GoodsReceiptItemRepository
        : IGoodsReceiptItemRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptItemRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetAllAsync()
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<GoodsReceiptItem?>
            GetByIdAsync(
                int goodsReceiptItemId)
        {
            return await _context.GoodsReceiptItems
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptItemId ==
                    goodsReceiptItemId);
        }


        // =========================================================
        // GET BY GOODS RECEIPT NOTE
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .Where(x =>
                    x.GoodsReceiptNoteId ==
                    goodsReceiptNoteId)
                .ToListAsync();
        }


        // =========================================================
        // GET SPECIFIC ITEM
        // =========================================================

        public async Task<GoodsReceiptItem?>
            GetByGoodsReceiptNoteAndItemAsync(
                int goodsReceiptNoteId,
                int goodsReceiptItemId)
        {
            return await _context.GoodsReceiptItems
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptNoteId ==
                        goodsReceiptNoteId
                    &&
                    x.GoodsReceiptItemId ==
                        goodsReceiptItemId);
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId
                    &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<GoodsReceiptItem>>
            SearchAsync(
                string? search,
                string? sort)
        {
            var query = _context.GoodsReceiptItems
                .AsNoTracking()
                .AsQueryable();

            // -----------------------------------------------------
            // SEARCH
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                if (int.TryParse(search, out int productId))
                {
                    query = query.Where(x =>
                        x.ProductId == productId);
                }
                else
                {
                    query = query.Where(x =>
                        x.Remarks != null &&
                        x.Remarks.Contains(search));
                }
            }

            // -----------------------------------------------------
            // SORT
            // -----------------------------------------------------

            query = sort?.ToLower() switch
            {
                "id_asc" =>
                    query.OrderBy(x =>
                        x.GoodsReceiptItemId),

                "id_desc" =>
                    query.OrderByDescending(x =>
                        x.GoodsReceiptItemId),

                "received_asc" =>
                    query.OrderBy(x =>
                        x.ReceivedQuantity),

                "received_desc" =>
                    query.OrderByDescending(x =>
                        x.ReceivedQuantity),

                "accepted_asc" =>
                    query.OrderBy(x =>
                        x.AcceptedQuantity),

                "accepted_desc" =>
                    query.OrderByDescending(x =>
                        x.AcceptedQuantity),

                "rejected_asc" =>
                    query.OrderBy(x =>
                        x.RejectedQuantity),

                "rejected_desc" =>
                    query.OrderByDescending(x =>
                        x.RejectedQuantity),

                _ =>
                    query.OrderBy(x =>
                        x.GoodsReceiptItemId)
            };

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<GoodsReceiptItem>>
    GetByProductIdAsync(int productId)
        {
            return await _context.GoodsReceiptItems
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
        public async Task<IEnumerable<GoodsReceiptItem>>
    SearchAsync(string? search)
        {
            var query = _context.GoodsReceiptItems
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                if (int.TryParse(search, out int id))
                {
                    query = query.Where(x =>
                        x.GoodsReceiptItemId == id ||
                        x.GoodsReceiptNoteId == id ||
                        x.ProductId == id ||
                        x.SellerId == id ||
                        x.CustomerId == id);
                }
                else
                {
                    query = query.Where(x =>
                        x.Remarks != null &&
                        x.Remarks.Contains(search));
                }
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<GoodsReceiptNoteItemStatistics>
            GetStatisticsAsync()
        {
            var query = _context.GoodsReceiptItems
                .AsNoTracking();

            return new GoodsReceiptNoteItemStatistics
            {
                TotalItems =
                    await query.CountAsync(),

                TotalReceivedQuantity =
                    await query.SumAsync(x =>
                        (decimal?)x.ReceivedQuantity) ?? 0,

                TotalAcceptedQuantity =
                    await query.SumAsync(x =>
                        (decimal?)x.AcceptedQuantity) ?? 0,

                TotalRejectedQuantity =
                    await query.SumAsync(x =>
                        (decimal?)x.RejectedQuantity) ?? 0,

                DistinctProducts =
                    await query
                        .Select(x => x.ProductId)
                        .Distinct()
                        .CountAsync(),

                DistinctGoodsReceiptNotes =
                    await query
                        .Select(x => x.GoodsReceiptNoteId)
                        .Distinct()
                        .CountAsync(),

                DistinctSellers =
                    await query
                        .Select(x => x.SellerId)
                        .Distinct()
                        .CountAsync(),

                DistinctCustomers =
                    await query
                        .Select(x => x.CustomerId)
                        .Distinct()
                        .CountAsync()
            };
        }


        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<GoodsReceiptItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 25;

            if (limit > 100)
                limit = 100;

            var query = _context.GoodsReceiptItems
                .AsNoTracking()
                .OrderBy(x =>
                    x.GoodsReceiptItemId);

            var totalCount =
                await query.CountAsync();

            var items =
                await query
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

        public async Task<IEnumerable<GoodsReceiptItem>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.GoodsReceiptItems
                .AsNoTracking()
                .AsQueryable();

            query = sort?.ToLower() switch
            {
                "id_asc" =>
                    query.OrderBy(x =>
                        x.GoodsReceiptItemId),

                "id_desc" =>
                    query.OrderByDescending(x =>
                        x.GoodsReceiptItemId),

                "received_asc" =>
                    query.OrderBy(x =>
                        x.ReceivedQuantity),

                "received_desc" =>
                    query.OrderByDescending(x =>
                        x.ReceivedQuantity),

                "accepted_asc" =>
                    query.OrderBy(x =>
                        x.AcceptedQuantity),

                "accepted_desc" =>
                    query.OrderByDescending(x =>
                        x.AcceptedQuantity),

                "rejected_asc" =>
                    query.OrderBy(x =>
                        x.RejectedQuantity),

                "rejected_desc" =>
                    query.OrderByDescending(x =>
                        x.RejectedQuantity),

                _ =>
                    query.OrderBy(x =>
                        x.GoodsReceiptItemId)
            };

            return await query.ToListAsync();
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            GoodsReceiptItem goodsReceiptItem)
        {
            await _context.GoodsReceiptItems
                .AddAsync(goodsReceiptItem);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            GoodsReceiptItem goodsReceiptItem)
        {
            _context.GoodsReceiptItems
                .Update(goodsReceiptItem);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int goodsReceiptItemId)
        {
            var entity =
                await GetByIdAsync(goodsReceiptItemId);

            if (entity != null)
            {
                _context.GoodsReceiptItems
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