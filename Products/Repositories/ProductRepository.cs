using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;

namespace Marketplacesellerportal.Products.Repositories
{
    public class ProductRepository
        : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetBySKUAsync(string sku)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SKU == sku);
        }

        public async Task<IEnumerable<Product>> GetBySellerAsync(
            int sellerId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>>
            GetProductsBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
    }
}