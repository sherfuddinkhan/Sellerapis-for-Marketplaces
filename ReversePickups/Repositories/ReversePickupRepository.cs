using Marketplacesellerportal.Database;
using Marketplacesellerportal.Interfaces;
using Marketplacesellerportal.ReversePickups.DTOs;
using Marketplacesellerportal.ReversePickups.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReversePickupEntity = Marketplacesellerportal.Models.ReversePickup;

namespace Marketplacesellerportal.ReversePickups.Repositories
{
    public class ReversePickupRepository : IReversePickupRepository
    {
        private readonly ApplicationDbContext _context;
        public ReversePickupRepository(ApplicationDbContext context) => _context = context;

        public async Task<ReversePickupEntity?> GetByIdAsync(int id, int sellerId, int customerId)
            => await _context.ReversePickups.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ReversePickupId == id && x.SellerId == sellerId && x.CustomerId == customerId);

        public async Task<(List<ReversePickupEntity> Items, int TotalCount)> GetListAsync(ReversePickupListRequest req)
        {
            req.Normalize();

            var query = _context.ReversePickups
                .AsNoTracking()
                .Where(x => x.SellerId == req.SellerId && x.CustomerId == req.CustomerId);

            // Exact filters - trimmed
            if (!string.IsNullOrWhiteSpace(req.ReversePickupNo))
            {
                var v = req.ReversePickupNo.Trim();
                query = query.Where(x => x.ReversePickupNo.Contains(v));
            }
            if (!string.IsNullOrWhiteSpace(req.SaleOrderCode))
            {
                var v = req.SaleOrderCode.Trim();
                query = query.Where(x => x.SaleOrderCode.Contains(v));
            }
            if (!string.IsNullOrWhiteSpace(req.ItemSkuCode))
            {
                var v = req.ItemSkuCode.Trim();
                query = query.Where(x => x.ItemSkuCode.Contains(v));
            }
            if (!string.IsNullOrWhiteSpace(req.Status))
            {
                var v = req.Status.Trim();
                query = query.Where(x => x.ReversePickupStatus == v);
            }
            if (!string.IsNullOrWhiteSpace(req.FacilityCode))
            {
                var v = req.FacilityCode.Trim();
                query = query.Where(x => x.FacilityCode == v);
            }

            // Global search - use LIKE to avoid ToLower() table scan
            if (!string.IsNullOrWhiteSpace(req.SearchTerm))
            {
                var s = $"%{req.SearchTerm.Trim()}%";
                query = query.Where(x =>
                    EF.Functions.Like(x.ReversePickupNo, s) ||
                    EF.Functions.Like(x.SaleOrderCode, s) ||
                    EF.Functions.Like(x.ItemSkuCode, s) ||
                    EF.Functions.Like(x.TrackingNo, s));
            }

            // Date range - make ToDate inclusive
            if (req.FromDate.HasValue)
                query = query.Where(x => x.CreatedDate >= req.FromDate.Value.Date);

            if (req.ToDate.HasValue)
            {
                var toDateEnd = req.ToDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.CreatedDate <= toDateEnd);
            }

            var totalCount = await query.CountAsync();

            query = req.SortOrder?.ToUpper() == "ASC"
                ? query.OrderBy(x => x.CreatedDate).ThenBy(x => x.ReversePickupId)
                : query.OrderByDescending(x => x.CreatedDate).ThenByDescending(x => x.ReversePickupId);

            var items = await query
                .Skip((req.PageNumber - 1) * req.PageSize)
                .Take(req.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<ReversePickupEntity> CreateAsync(ReversePickupEntity e)
        {
            e.CreatedDate = DateTime.UtcNow;
            var en = await _context.ReversePickups.AddAsync(e);
            await _context.SaveChangesAsync();
            return en.Entity;
        }

        public async Task<ReversePickupEntity?> UpdateAsync(ReversePickupEntity e)
        {
            var ex = await _context.ReversePickups.FirstOrDefaultAsync(x => x.ReversePickupId == e.ReversePickupId && x.SellerId == e.SellerId && x.CustomerId == e.CustomerId);
            if (ex == null) return null;
            ex.ReversePickupNo = e.ReversePickupNo;
            ex.SaleOrderCode = e.SaleOrderCode;
            ex.SaleOrderItemCode = e.SaleOrderItemCode;
            ex.ItemSkuCode = e.ItemSkuCode;
            ex.TrackingNo = e.TrackingNo;
            ex.ReturnReason = e.ReturnReason;
            ex.QCComment = e.QCComment;
            ex.ReversePickupStatus = e.ReversePickupStatus;
            ex.CourierProviderName = e.CourierProviderName;
            ex.FacilityCode = e.FacilityCode;
            ex.ChannelName = e.ChannelName;
            ex.PutawayCode = e.PutawayCode;
            ex.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return ex;
        }

        public async Task<bool> DeleteAsync(int id, int s, int c)
        {
            var e = await _context.ReversePickups.FirstOrDefaultAsync(x => x.ReversePickupId == id && x.SellerId == s && x.CustomerId == c);
            if (e == null) return false;
            _context.ReversePickups.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}