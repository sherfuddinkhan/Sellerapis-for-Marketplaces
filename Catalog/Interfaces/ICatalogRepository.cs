using Marketplacesellerportal.Catalog.DTOs;

namespace Marketplacesellerportal.Catalog.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogProductResponse>> GetProductsAsync();

        Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId);

        Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request);

        Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(int brandId);

        Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(int categoryId);

        Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(int productTypeId);

        Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync();

        Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync();

        Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync();

        Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync();

        Task<IEnumerable<BrandResponse>> GetBrandsAsync();

        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();

        Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(int productId);

        Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(int productId);

        Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(int productId);

        Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(int productId);
    }
}
