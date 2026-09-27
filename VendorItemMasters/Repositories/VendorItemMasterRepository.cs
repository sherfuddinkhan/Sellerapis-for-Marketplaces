using Marketplacesellerportal.Database;
using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.VendorItemMaster.DTOs;
using Marketplacesellerportal.VendorItemMasters.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VendorItemMasterEntity = Marketplacesellerportal.Models.VendorItemMaster;

namespace Marketplacesellerportal.VendorItemMasters.Repositories
{
    public class VendorItemMasterRepository : IVendorItemMasterRepository
    {
        private readonly ApplicationDbContext _context;
        public VendorItemMasterRepository(ApplicationDbContext context) => _context = context;

        public Task<VendorItemMasterEntity?> GetByIdAsync(int id, int sellerId, int customerId)
            => _context.VendorItemMasters.FirstOrDefaultAsync(x => x.VendorItemMasterId == id && x.SellerId == sellerId && x.CustomerId == customerId);

        public async Task<(System.Collections.Generic.List<VendorItemMasterEntity> Items, int TotalCount)> GetListAsync(VendorItemMasterListRequest req)
        {
            var q = _context.VendorItemMasters.Where(x => x.SellerId == req.SellerId && x.CustomerId == req.CustomerId);
            var total = await q.CountAsync();
            var items = await q.Skip((req.PageNumber - 1) * req.PageSize).Take(req.PageSize).ToListAsync();
            return (items, total);
        }

        public async Task<VendorItemMasterEntity> CreateAsync(VendorItemMasterEntity e) { e.CreatedDate = DateTime.UtcNow; var en = await _context.VendorItemMasters.AddAsync(e); await _context.SaveChangesAsync(); return en.Entity; }
        public async Task<VendorItemMasterEntity?> UpdateAsync(VendorItemMasterEntity e) { var ex = await _context.VendorItemMasters.FirstOrDefaultAsync(x => x.VendorItemMasterId == e.VendorItemMasterId); if (ex == null) return null; ex.VendorSkuCode = e.VendorSkuCode; ex.ItemSkuCode = e.ItemSkuCode; ex.CostPrice = e.CostPrice; ex.UpdatedDate = DateTime.UtcNow; await _context.SaveChangesAsync(); return ex; }
        public async Task<bool> DeleteAsync(int id, int s, int c) { var e = await _context.VendorItemMasters.FirstOrDefaultAsync(x => x.VendorItemMasterId == id && x.SellerId == s && x.CustomerId == c); if (e == null) return false; _context.VendorItemMasters.Remove(e); await _context.SaveChangesAsync(); return true; }
        public Task<bool> ExistsByVendorSkuAsync(string sku, int vendorId, int sellerId, int customerId) => _context.VendorItemMasters.AnyAsync(x => x.VendorSkuCode == sku && x.VendorId == vendorId && x.SellerId == sellerId && x.CustomerId == customerId);
    }
}