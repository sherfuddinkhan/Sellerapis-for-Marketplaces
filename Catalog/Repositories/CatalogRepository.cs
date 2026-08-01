using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;

namespace Marketplacesellerportal.Catalog.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CatalogProductResponse>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(int productTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BrandResponse>> GetBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
