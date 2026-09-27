using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Gatepasses.DTOs;
using Marketplacesellerportal.Gatepasses.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Gatepasses.Repositories
{
    public class GatepassRepository : IGatepassRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gatepass> _dbSet;

        public GatepassRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Gatepass>();
        }

        public async Task<Gatepass?> GetByIdAsync(int gatepassId, int sellerId, int customerId)
        {
            return await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(x => x.GatepassId == gatepassId && x.SellerId == sellerId && x.CustomerId == customerId);
        }

        public async Task<Gatepass?> GetByCodeAsync(string gatepassCode, int sellerId, int customerId)
        {
            return await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(x => x.GatepassCode == gatepassCode && x.SellerId == sellerId && x.CustomerId == customerId);
        }

        public async Task<(List<Gatepass> Items, int TotalCount)> GetListAsync(GatepassListRequest request)
        {
            var query = _dbSet.AsNoTracking()
                .Where(x => x.SellerId == request.SellerId && x.CustomerId == request.CustomerId);

            if (!string.IsNullOrWhiteSpace(request.GatepassCode))
                query = query.Where(x => x.GatepassCode.Contains(request.GatepassCode));
            if (!string.IsNullOrWhiteSpace(request.FacilityCode))
                query = query.Where(x => x.FacilityCode.Contains(request.FacilityCode));
            if (!string.IsNullOrWhiteSpace(request.ItemSkuCode))
                query = query.Where(x => x.ItemSkuCode.Contains(request.ItemSkuCode));
            if (!string.IsNullOrWhiteSpace(request.Status))
                query = query.Where(x => x.Status == request.Status);

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<Gatepass>> GetAllBySellerCustomerAsync(int sellerId, int customerId)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.SellerId == sellerId && x.CustomerId == customerId)
                .OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<Gatepass> CreateAsync(Gatepass entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Gatepass?> UpdateAsync(Gatepass entity)
        {
            var existing = await _dbSet.FirstOrDefaultAsync(x => x.GatepassId == entity.GatepassId && x.SellerId == entity.SellerId && x.CustomerId == entity.CustomerId);
            if (existing == null) return null;

            existing.GatepassCode = entity.GatepassCode;
            existing.FacilityCode = entity.FacilityCode;
            existing.ItemSkuCode = entity.ItemSkuCode;
            existing.Quantity = entity.Quantity;
            existing.Reason = entity.Reason;
            existing.Status = entity.Status;
            existing.Facility = entity.Facility;
            existing.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int gatepassId, int sellerId, int customerId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.GatepassId == gatepassId && x.SellerId == sellerId && x.CustomerId == customerId);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int gatepassId, int sellerId, int customerId)
        {
            return await _dbSet.AnyAsync(x => x.GatepassId == gatepassId && x.SellerId == sellerId && x.CustomerId == customerId);
        }
    }
}