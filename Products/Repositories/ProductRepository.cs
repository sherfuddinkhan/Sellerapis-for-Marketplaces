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
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        // =========================================================
        // GET PRODUCT BY SKU
        // =========================================================
        public async Task<Product?> GetBySKUAsync(string sku)
        {
            var product = await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SKU == sku);

            if (product == null)
                return null;

            await MapBrandNameAsync(product);

            return product;
        }

        // =========================================================
        // GET PRODUCTS BY SELLER
        // =========================================================
        public async Task<IEnumerable<Product>> GetBySellerAsync(
            int sellerId)
        {
            var products = await _dbSet
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();

            await MapBrandNamesAsync(products);

            return products;
        }

        // =========================================================
        // GET PRODUCTS BY SELLER + CUSTOMER
        // =========================================================
        public async Task<IEnumerable<Product>>
            GetProductsBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            var products = await _dbSet
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();

            await MapBrandNamesAsync(products);

            return products;
        }

        // =========================================================
        // MAP BRAND NAME FOR ONE PRODUCT
        // =========================================================
        private async Task MapBrandNameAsync(Product product)
        {
            if (!product.BrandId.HasValue)
            {
                product.BrandName = null;
                return;
            }

            product.BrandName = await _context.Brands
                .AsNoTracking()
                .Where(b => b.BrandId == product.BrandId.Value)
                .Select(b => b.BrandName)
                .FirstOrDefaultAsync();
        }

        // =========================================================
        // MAP BRAND NAMES FOR MULTIPLE PRODUCTS
        // =========================================================
        private async Task MapBrandNamesAsync(
            IEnumerable<Product> products)
        {
            var productList = products.ToList();

            var brandIds = productList
                .Where(p => p.BrandId.HasValue)
                .Select(p => p.BrandId!.Value)
                .Distinct()
                .ToList();

            if (!brandIds.Any())
                return;

            var brands = await _context.Brands
                .AsNoTracking()
                .Where(b => brandIds.Contains(b.BrandId))
                .ToDictionaryAsync(
                    b => b.BrandId,
                    b => b.BrandName);

            foreach (var product in productList)
            {
                if (product.BrandId.HasValue &&
                    brands.TryGetValue(
                        product.BrandId.Value,
                        out var brandName))
                {
                    product.BrandName = brandName;
                }
            }
        }
    }
}