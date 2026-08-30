using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Catalog.DTOs;
namespace Marketplacesellerportal.Catalog.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogProductResponse>> GetProductsAsync(int sellerId,int customerId);
        Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId,int sellerId,int customerId);
        Task<Product> CreateProductAsync(CreateProductRequest request);
        Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request,int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(int brandId,int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(int categoryId,int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(int productTypeId,int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync( int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync(int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync(int sellerId, int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetAllCatalogProductsAsync();
        Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync(int sellerId,int customerId);
        Task<IEnumerable<BrandResponse>> GetBrandsAsync(int sellerId,int customerId);
        Task<IEnumerable<CatalogCategoryResponse>> GetCategoriesAsync(int sellerId,int customerId);
        Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(int productId, int sellerId, int customerId);
        Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(int productId,int sellerId,int customerId);
        Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(int productId,int sellerId,int customerId);
        Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(int productId,int sellerId,int customerId);
        Task<List<CatalogProductResponse>> GetAllAsync();

        Task<CatalogProductResponse?> GetByIdAsync(
            int productId,
            int sellerId,
            int customerId);
        Task<bool> UpdateProductAsync(int productId,int sellerId,int customerId,UpdateProductRequest request);
        Task<bool> DeleteProductAsync(int productId,int sellerId,int customerId);
    }
}