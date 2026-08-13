using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Catalog.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;

        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> CreateProductAsync(CreateProductRequest request)
        {
            return await _repository.CreateProductAsync(request);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task<ProductDetailsResponse?> GetProductDetailsAsync(
            int productId)
        {
            return await _repository.GetProductDetailsAsync(productId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(
            ProductSearchRequest request)
        {
            return await _repository.SearchProductsAsync(request);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(
            int brandId)
        {
            return await _repository.GetProductsByBrandAsync(brandId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(
            int categoryId)
        {
            return await _repository.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(
            int productTypeId)
        {
            return await _repository.GetProductsByProductTypeAsync(productTypeId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync()
        {
            return await _repository.GetLatestProductsAsync();
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync()
        {
            return await _repository.GetFeaturedProductsAsync();
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync()
        {
            return await _repository.GetTopRatedProductsAsync();
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync()
        {
            return await _repository.GetBestSellingProductsAsync();
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync()
        {
            return await _repository.GetBrandsAsync();
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            return await _repository.GetCategoriesAsync();
        }

        public async Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(
            int productId)
        {
            return await _repository.GetProductImagesAsync(productId);
        }

        public async Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(
            int productId)
        {
            return await _repository.GetProductAttributesAsync(productId);
        }

        public async Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(
            int productId)
        {
            return await _repository.GetProductReviewsAsync(productId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(
            int productId)
        {
            return await _repository.GetRelatedProductsAsync(productId);
        }
    }
}