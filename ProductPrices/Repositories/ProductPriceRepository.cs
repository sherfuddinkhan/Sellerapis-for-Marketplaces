using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.Interfaces;

namespace Marketplacesellerportal.ProductPrices.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync()
        {
            return await _context.ProductPrices.ToListAsync();
        }

        public async Task<ProductPrice?> GetByIdAsync(int productPriceId)
        {
            return await _context.ProductPrices
                .FirstOrDefaultAsync(x => x.ProductPriceId == productPriceId);
        }

        public async Task<IEnumerable<ProductPrice>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductPrices
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductPrice>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.ProductPrices
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductPrice>> GetByPriceTypeAsync(string priceType)
        {
            return await _context.ProductPrices
                .Where(x => x.PriceType == priceType)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductPrice>> GetActivePricesAsync()
        {
            return await _context.ProductPrices
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<ProductPrice?> GetProductPriceAsync(
            int sellerId,
            int productId,
            string priceType)
        {
            return await _context.ProductPrices.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.PriceType == priceType);
        }

        public async Task AddAsync(ProductPrice productPrice)
        {
            await _context.ProductPrices.AddAsync(productPrice);
        }

        public Task UpdateAsync(ProductPrice productPrice)
        {
            _context.ProductPrices.Update(productPrice);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productPriceId)
        {
            var entity = await GetByIdAsync(productPriceId);

            if (entity != null)
                _context.ProductPrices.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
