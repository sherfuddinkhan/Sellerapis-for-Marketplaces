using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductImages.Interfaces;

namespace Marketplacesellerportal.ProductImages.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductImage>> GetByProductIdsAsync(
    IEnumerable<int> productIds)
        {
            return await _context.ProductImages
                .Where(x => productIds.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .ThenBy(x => x.DisplayOrder)
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }
    
        public async Task<ProductImage?> GetByIdAsync(int productImageId)
        {
            return await _context.ProductImages
                .FirstOrDefaultAsync(x => x.ProductImageId == productImageId);
        }

        public async Task<IEnumerable<ProductImage>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductImages
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetPrimaryImagesAsync()
        {
            return await _context.ProductImages
                .Where(x => x.IsPrimary == true)
                .ToListAsync();
        }

        public async Task<ProductImage?> GetPrimaryImageAsync(int productId)
        {
            return await _context.ProductImages
                .FirstOrDefaultAsync(x =>
                    x.ProductId == productId &&
                    x.IsPrimary == true);
        }

        public async Task AddAsync(ProductImage productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
        }

        public Task UpdateAsync(ProductImage productImage)
        {
            _context.ProductImages.Update(productImage);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productImageId)
        {
            var entity = await GetByIdAsync(productImageId);

            if (entity != null)
                _context.ProductImages.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
