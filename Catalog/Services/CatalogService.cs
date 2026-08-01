using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;

namespace Marketplacesellerportal.Catalog.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;

        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<CatalogProductResponse>> GetProductsAsync()
            => _repository.GetProductsAsync();

        public Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId)
            => _repository.GetProductDetailsAsync(productId);

        public Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request)
            => _repository.SearchProductsAsync(request);

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(int brandId)
            => _repository.GetProductsByBrandAsync(brandId);

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(int categoryId)
            => _repository.GetProductsByCategoryAsync(categoryId);

        public Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(int productTypeId)
            => _repository.GetProductsByProductTypeAsync(productTypeId);

        public Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync()
            => _repository.GetLatestProductsAsync();

        public Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync()
            => _repository.GetFeaturedProductsAsync();

        public Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync()
            => _repository.GetTopRatedProductsAsync();

        public Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync()
            => _repository.GetBestSellingProductsAsync();

        public Task<IEnumerable<BrandResponse>> GetBrandsAsync()
            => _repository.GetBrandsAsync();

        public Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
            => _repository.GetCategoriesAsync();

        public Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(int productId)
            => _repository.GetProductImagesAsync(productId);

        public Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(int productId)
            => _repository.GetProductAttributesAsync(productId);

        public Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(int productId)
            => _repository.GetProductReviewsAsync(productId);

        public Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(int productId)
            => _repository.GetRelatedProductsAsync(productId);
    }
}
