using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Catalog.Interfaces
{
    public interface ICatalogRepository
    {
        // =========================================================
        // PRODUCTS
        // =========================================================

        Task<IEnumerable<CatalogProductResponse>> GetProductsAsync(
            int sellerId,
            int customerId);

        Task<ProductDetailsResponse?> GetProductDetailsAsync(
            int productId,
            int sellerId,
            int customerId);

        Task<Product> CreateProductAsync(
            CreateProductRequest request);

        Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(
            ProductSearchRequest request,
            int sellerId,
            int customerId);

        // =========================================================
        // PRODUCT FILTERS
        // =========================================================

        Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(
            int brandId,
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(
            int categoryId,
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(
            int productTypeId,
            int sellerId,
            int customerId);

        // =========================================================
        // PRODUCT LISTS
        // =========================================================

        Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync(
            int sellerId,
            int customerId);

        // =========================================================
        // BRANDS
        // =========================================================

        Task<IEnumerable<BrandResponse>> GetBrandsAsync(
            int sellerId,
            int customerId);

        // =========================================================
        // CATEGORIES
        // =========================================================

        Task<IEnumerable<CatalogCategoryResponse>> GetCategoriesAsync(
            int sellerId,
            int customerId);

        // =========================================================
        // PRODUCT DETAILS
        // =========================================================

        Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(
            int productId,
            int sellerId,
            int customerId);

        Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(
            int productId,
            int sellerId,
            int customerId);

        Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(
            int productId,
            int sellerId,
            int customerId);

        Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(
            int productId,
            int sellerId,
            int customerId);

        // =========================================================
        // UPDATE / DELETE
        // =========================================================

        Task<Product?> GetProductForSellerCustomerAsync(
            int productId,
            int sellerId,
            int customerId);

        Task UpdateProductAsync(
            Product product);

        Task DeleteProductAsync(
            Product product);

        Task SaveChangesAsync();
    }
}