using Marketplacesellerportal.Database;
using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ShelfwiseInventory.DTOs;
using Marketplacesellerportal.ShelfwiseInventory.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ALIAS - FIX for "is a namespace but is used like a type"
using ShelfwiseInventoryEntity = Marketplacesellerportal.Models.ShelfwiseInventory;

namespace Marketplacesellerportal.ShelfwiseInventory.Repositories
{
    public class ShelfwiseInventoryRepository : IShelfwiseInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ShelfwiseInventoryRepository(ApplicationDbContext context) => _context = context;

        public async Task<ShelfwiseInventoryEntity?> GetByIdAsync(int id, int sellerId, int customerId)
            => await _context.ShelfwiseInventories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ShelfwiseInventoryId == id && x.SellerId == sellerId && x.CustomerId == customerId);

        public async Task<(List<ShelfwiseInventoryEntity> Items, int TotalCount)> GetListAsync(ShelfwiseInventoryListRequest req)
        {
            var q = _context.ShelfwiseInventories.AsNoTracking()
                .Where(x => x.SellerId == req.SellerId && x.CustomerId == req.CustomerId);

            if (!string.IsNullOrWhiteSpace(req.FacilityCode))
                q = q.Where(x => x.FacilityCode.Contains(req.FacilityCode));
            if (!string.IsNullOrWhiteSpace(req.ShelfCode))
                q = q.Where(x => x.ShelfCode.Contains(req.ShelfCode));
            if (!string.IsNullOrWhiteSpace(req.ItemSkuCode))
                q = q.Where(x => x.ItemSkuCode.Contains(req.ItemSkuCode));
            if (!string.IsNullOrWhiteSpace(req.BatchCode))
                q = q.Where(x => x.BatchCode.Contains(req.BatchCode));
            if (!string.IsNullOrWhiteSpace(req.InventoryType))
                q = q.Where(x => x.InventoryType == req.InventoryType);

            if (!string.IsNullOrWhiteSpace(req.SearchTerm))
            {
                var s = req.SearchTerm.ToLower();
                q = q.Where(x => x.FacilityCode.ToLower().Contains(s) || x.ShelfCode.ToLower().Contains(s) || x.ItemSkuCode.ToLower().Contains(s) || x.BatchCode.ToLower().Contains(s));
            }

            var total = await q.CountAsync();
            q = req.SortOrder == "ASC" ? q.OrderBy(x => x.CreatedDate) : q.OrderByDescending(x => x.CreatedDate);
            var items = await q.Skip((req.PageNumber - 1) * req.PageSize).Take(req.PageSize).ToListAsync();
            return (items, total);
        }

        public async Task<ShelfwiseInventoryEntity> CreateAsync(ShelfwiseInventoryEntity e)
        {
            e.CreatedDate = DateTime.UtcNow;
            var en = await _context.ShelfwiseInventories.AddAsync(e);
            await _context.SaveChangesAsync();
            return en.Entity;
        }

        public async Task<ShelfwiseInventoryEntity?> UpdateAsync(ShelfwiseInventoryEntity e)
        {
            var ex = await _context.ShelfwiseInventories.FirstOrDefaultAsync(x => x.ShelfwiseInventoryId == e.ShelfwiseInventoryId && x.SellerId == e.SellerId && x.CustomerId == e.CustomerId);
            if (ex == null) return null;
            ex.FacilityCode = e.FacilityCode;
            ex.ShelfCode = e.ShelfCode;
            ex.ItemSkuCode = e.ItemSkuCode;
            ex.Quantity = e.Quantity;
            ex.BatchCode = e.BatchCode;
            ex.ExpiryDate = e.ExpiryDate;
            ex.InventoryType = e.InventoryType;
            ex.LocationCode = e.LocationCode;
            ex.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return ex;
        }

        public async Task<bool> DeleteAsync(int id, int s, int c)
        {
            var e = await _context.ShelfwiseInventories.FirstOrDefaultAsync(x => x.ShelfwiseInventoryId == id && x.SellerId == s && x.CustomerId == c);
            if (e == null) return false;
            _context.ShelfwiseInventories.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}