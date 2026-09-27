using Marketplacesellerportal.Database;
using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Putaways.DTOs;
using Marketplacesellerportal.Putaways.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Fix "Putaway is a namespace" error
using PutawayEntity = Marketplacesellerportal.Models.Putaway;

namespace Marketplacesellerportal.Putaways.Repositories
{
    public class PutawayRepository : IPutawayRepository
    {
        private readonly ApplicationDbContext _context;

        public PutawayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PutawayEntity?> GetByIdAsync(int id, int sellerId, int customerId)
        {
            return await _context.Putaways
                .FirstOrDefaultAsync(x => x.PutawayId == id && x.SellerId == sellerId && x.CustomerId == customerId);
        }

        public async Task<(List<PutawayEntity> items, int totalCount)> GetListAsync(PutawayListRequest request)
        {
            var query = _context.Putaways.AsQueryable();
            query = query.Where(x => x.SellerId == request.SellerId && x.CustomerId == request.CustomerId);

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(x =>
                    x.PutawayCode.Contains(request.SearchTerm) ||
                    x.ShelfCode.Contains(request.SearchTerm));
            }

            var total = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.PutawayId)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<PutawayEntity> CreateAsync(PutawayEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _context.Putaways.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PutawayEntity?> UpdateAsync(PutawayEntity entity)
        {
            var existing = await _context.Putaways.FindAsync(entity.PutawayId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id, int sellerId, int customerId)
        {
            var entity = await _context.Putaways
                .FirstOrDefaultAsync(x => x.PutawayId == id && x.SellerId == sellerId && x.CustomerId == customerId);
            if (entity == null) return false;

            _context.Putaways.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PutawayStatistics> GetStatisticsAsync(int sellerId, int customerId)
        {
            var query = _context.Putaways.Where(x => x.SellerId == sellerId && x.CustomerId == customerId);
            return new PutawayStatistics
            {
                Total = await query.CountAsync(),
                Created = await query.CountAsync(x => x.StatusCode == "CREATED"),
                Completed = await query.CountAsync(x => x.StatusCode == "COMPLETED")
            };
        }

        public async Task<bool> ExistsAsync(int id, int sellerId, int customerId)
        {
            return await _context.Putaways
                .AnyAsync(x => x.PutawayId == id && x.SellerId == sellerId && x.CustomerId == customerId);
        }
    }
}