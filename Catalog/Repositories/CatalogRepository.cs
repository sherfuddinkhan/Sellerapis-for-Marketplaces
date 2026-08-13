using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Catalog.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsAsync()
        {
            var products = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET PRODUCT DETAILS
        // =========================================================
        public async Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return null;
            }

            var response = new ProductDetailsResponse
            {
                Product = new CatalogProductResponse
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    BrandName = "",
                    CategoryName = "",
                    ProductType = "",
                    Price = 0,
                    OfferPrice = null,
                    StockQuantity = 0,
                    PrimaryImage = null,
                    Rating = 0,
                    ReviewCount = 0,
                    IsAvailable = product.IsActive == true
                },

                Images = new List<ProductImageResponse>(),

                Attributes = new List<ProductAttributeResponse>(),

                Reviews = new List<ProductReviewResponse>(),

                RelatedProducts = new List<CatalogProductResponse>()
            };

            return response;
        }

        // =========================================================
        // SEARCH PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(
            ProductSearchRequest request)
        {
            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            if (request != null)
            {
                // Add search condition here according to the actual
                // properties in ProductSearchRequest.
            }

            var products = await query.ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET PRODUCTS BY BRAND
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(
            int brandId)
        {
            // This requires BrandId to exist in Product.
            // Until the Product model contains BrandId, return
            // the active product list rather than throwing an exception.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET PRODUCTS BY CATEGORY
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(
            int categoryId)
        {
            // This requires CategoryId to exist in Product.
            // Implement the filter after confirming your Product model.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET PRODUCTS BY PRODUCT TYPE
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(
            int productTypeId)
        {
            // This requires ProductTypeId in Product.
            // Current implementation returns active products.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET LATEST PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync()
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET FEATURED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync()
        {
            // If Product has IsFeatured, use:
            //
            // .Where(p => p.IsActive && p.IsFeatured)

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET TOP RATED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync()
        {
            // Rating requires a Review table or Rating column.
            // Until that relationship is available, return active products.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET BEST SELLING PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync()
        {
            // Best-selling requires order/sales information.
            // Until that table is connected, return active products.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // GET BRANDS
        // =========================================================
        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync()
        {
            // This requires:
            // _context.Brands
            //
            // We are not adding it here because your current
            // ApplicationDbContext/Brand model was not provided.

            return Enumerable.Empty<BrandResponse>();
        }

        // =========================================================
        // GET CATEGORIES
        // =========================================================
        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .Where(c => c.IsActive == true)
                .ToListAsync();

            return categories.Select(c => new CategoryResponse
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }

        // =========================================================
        // GET PRODUCT IMAGES
        // =========================================================
        public async Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(
            int productId)
        {
            // ProductImages must exist in ApplicationDbContext before
            // this can be connected to the database.

            return Enumerable.Empty<ProductImageResponse>();
        }

        // =========================================================
        // GET PRODUCT ATTRIBUTES
        // =========================================================
        public async Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(
            int productId)
        {
            // ProductAttributes must exist in ApplicationDbContext.

            return Enumerable.Empty<ProductAttributeResponse>();
        }

        // =========================================================
        // GET PRODUCT REVIEWS
        // =========================================================
        public async Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(
            int productId)
        {
            // ProductReviews must exist in ApplicationDbContext.

            return Enumerable.Empty<ProductReviewResponse>();
        }

        // =========================================================
        // GET RELATED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(
            int productId)
        {
            var currentProduct = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (currentProduct == null)
            {
                return Enumerable.Empty<CatalogProductResponse>();
            }

            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.ProductId != productId &&
                    p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .Take(10)
                .ToListAsync();

            return products.Select(MapProduct).ToList();
        }

        // =========================================================
        // COMMON PRODUCT MAPPING
        // =========================================================
        private static CatalogProductResponse MapProduct(dynamic p)
        {
            return new CatalogProductResponse
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                BrandName = "",
                CategoryName = "",
                ProductType = "",
                Price = 0,
                OfferPrice = null,
                StockQuantity = 0,
                PrimaryImage = null,
                Rating = 0,
                ReviewCount = 0,
                IsAvailable = p.IsActive == true
            };
        }
        public async Task<Product> CreateProductAsync(CreateProductRequest request)
        {
            var product = new Product
            {
                SellerId = request.SellerId,
                SKU = request.SKU,
                ProductName = request.ProductName,
                Description = request.Description,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Barcode = request.Barcode,
                HSNCode = request.HSNCode,
                UnitOfMeasure = request.UnitOfMeasure,
                Weight = request.Weight,
                Length = request.Length,
                Width = request.Width,
                Height = request.Height,
                Status = string.IsNullOrWhiteSpace(request.Status)
                    ? "Active"
                    : request.Status,
                IsActive = request.IsActive ?? true,
                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}