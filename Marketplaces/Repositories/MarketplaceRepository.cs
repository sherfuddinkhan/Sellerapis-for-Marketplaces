using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Marketplaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Marketplaces.Repositories
{
    public class MarketplaceRepository
        : IMarketplaceRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketplaceRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marketplace>>
            GetAllAsync()
        {
            return await _context.Marketplaces
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Marketplace?>
            GetByIdAsync(int marketplaceId)
        {
            return await _context.Marketplaces
                .FirstOrDefaultAsync(x =>
                    x.MarketplaceId == marketplaceId);
        }

        public async Task<Marketplace?>
            GetByCodeAsync(string marketplaceCode)
        {
            return await _context.Marketplaces
                .FirstOrDefaultAsync(x =>
                    x.MarketplaceCode == marketplaceCode);
        }

        public async Task<IEnumerable<Marketplace>>
            GetActiveAsync()
        {
            return await _context.Marketplaces
                .Where(x => x.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Marketplace>>
            SearchAsync(string? search)
        {
            var query = _context.Marketplaces
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.MarketplaceName.Contains(search) ||
                    x.MarketplaceCode.Contains(search) ||
                    (x.Description != null &&
                     x.Description.Contains(search)));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Marketplace>>
            GetSortedAsync(string? sort)
        {
            var query = _context.Marketplaces
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "name_asc":
                    query = query.OrderBy(
                        x => x.MarketplaceName);
                    break;

                case "name_desc":
                    query = query.OrderByDescending(
                        x => x.MarketplaceName);
                    break;

                case "code_asc":
                    query = query.OrderBy(
                        x => x.MarketplaceCode);
                    break;

                case "code_desc":
                    query = query.OrderByDescending(
                        x => x.MarketplaceCode);
                    break;

                case "date_asc":
                    query = query.OrderBy(
                        x => x.CreatedDate);
                    break;

                case "date_desc":
                    query = query.OrderByDescending(
                        x => x.CreatedDate);
                    break;

                default:
                    query = query.OrderBy(
                        x => x.MarketplaceName);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(
            Marketplace marketplace)
        {
            await _context.Marketplaces
                .AddAsync(marketplace);
        }

        public Task UpdateAsync(
            Marketplace marketplace)
        {
            _context.Marketplaces
                .Update(marketplace);

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(
            int marketplaceId)
        {
            var marketplace =
                await GetByIdAsync(marketplaceId);

            if (marketplace != null)
            {
                _context.Marketplaces
                    .Remove(marketplace);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
