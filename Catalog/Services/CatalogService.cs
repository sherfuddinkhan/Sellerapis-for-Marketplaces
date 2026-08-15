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

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductsAsync(
                sellerId,
                customerId);
        }

        public async Task<ProductDetailsResponse?> GetProductDetailsAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductDetailsAsync(
                productId,
                sellerId,
                customerId);
        }

        public async Task<Product> CreateProductAsync(
            CreateProductRequest request)
        {
            return await _repository.CreateProductAsync(request);
        }

        public async Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(
            ProductSearchRequest request,
            int sellerId,
            int customerId)
        {
            return await _repository.SearchProductsAsync(
                request,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(
            int brandId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductsByBrandAsync(
                brandId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(
            int categoryId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductsByCategoryAsync(
                categoryId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(
            int productTypeId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductsByProductTypeAsync(
                productTypeId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetLatestProductsAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetFeaturedProductsAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetTopRatedProductsAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBestSellingProductsAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBrandsAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetCategoriesAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductImagesAsync(
                productId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductAttributesAsync(
                productId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetProductReviewsAsync(
                productId,
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetRelatedProductsAsync(
                productId,
                sellerId,
                customerId);
        }
    }
}