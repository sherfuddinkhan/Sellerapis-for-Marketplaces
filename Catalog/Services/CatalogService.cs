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

        public async Task<IEnumerable<CatalogProductResponse>> GetProductsAsync(int sellerId,int customerId)
        {
            return await _repository.GetProductsAsync(sellerId,customerId);
        }
        public async Task<ProductDetailsResponse?> GetProductDetailsAsync(int productId,int sellerId,int customerId)
        {
            return await _repository.GetProductDetailsAsync(productId,sellerId,customerId);
        }

        public async Task<Product> CreateProductAsync(CreateProductRequest request)
        {
            return await _repository.CreateProductAsync(request);
        }
        public async Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request,int sellerId,int customerId)
        {
            return await _repository.SearchProductsAsync(request,sellerId,customerId);
        }
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByBrandAsync(int brandId,int sellerId,int customerId)
        {
            return await _repository.GetProductsByBrandAsync(brandId,sellerId,customerId);
        }
        public async Task<IEnumerable<CatalogProductResponse>>
    GetAllCatalogProductsAsync()
        {
            return await _repository.GetAllCatalogProductsAsync();
        }
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByCategoryAsync(int categoryId,int sellerId,int customerId)
        {
            return await _repository.GetProductsByCategoryAsync(categoryId,sellerId,customerId);
        }
        public async Task<List<CatalogProductResponse>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CatalogProductResponse?> GetByIdAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            return await _repository.GetByIdAsync(
                productId,
                sellerId,
                customerId
            );
        }
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsByProductTypeAsync(int productTypeId,int sellerId,int customerId)
        {
            return await _repository.GetProductsByProductTypeAsync(productTypeId,sellerId,customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetLatestProductsAsync(int sellerId,int customerId)
        {
            return await _repository.GetLatestProductsAsync(sellerId,customerId);
        }
        public async Task<IEnumerable<CatalogProductResponse>> GetFeaturedProductsAsync(int sellerId,int customerId)
        {
            return await _repository.GetFeaturedProductsAsync(sellerId,customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetTopRatedProductsAsync(int sellerId,int customerId)
        {
            return await _repository.GetTopRatedProductsAsync(sellerId,customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetBestSellingProductsAsync(int sellerId,int customerId)
        {
            return await _repository.GetBestSellingProductsAsync(sellerId,customerId);
        }
        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(int sellerId,int customerId)
        {
            return await _repository.GetBrandsAsync(sellerId,customerId);
        }

        public async Task<IEnumerable<CatalogCategoryResponse>> GetCategoriesAsync(int sellerId,int customerId)
        {
            return await _repository.GetCategoriesAsync(sellerId,customerId);
        }

        public async Task<IEnumerable<ProductImageResponse>> GetProductImagesAsync(int productId,int sellerId,int customerId)
        {
            return await _repository.GetProductImagesAsync(productId,sellerId,customerId);
        }

        public async Task<IEnumerable<ProductAttributeResponse>> GetProductAttributesAsync(int productId,int sellerId,int customerId)
        {
            return await _repository.GetProductAttributesAsync(productId,sellerId,customerId);
        }

        public async Task<IEnumerable<ProductReviewResponse>> GetProductReviewsAsync(int productId,int sellerId,int customerId)
        {
            return await _repository.GetProductReviewsAsync(productId,sellerId,customerId);
        }

        public async Task<IEnumerable<CatalogProductResponse>> GetRelatedProductsAsync(int productId,int sellerId,int customerId)
        {
            return await _repository.GetRelatedProductsAsync(productId,sellerId,customerId);
        }
        public async Task<bool> UpdateProductAsync(int productId,int sellerId,int customerId,UpdateProductRequest request)
        {
            var product = await _repository.GetProductForSellerCustomerAsync(productId,sellerId,customerId);

            if (product == null)
            {
                return false;
            }

            if (request.SKU != null)
            {
                product.SKU = request.SKU;
            }

            if (request.ProductName != null)
            {
                product.ProductName = request.ProductName;
            }

            if (request.Description != null)
            {
                product.Description = request.Description;
            }

            if (request.BrandId.HasValue)
            {
                product.BrandId = request.BrandId.Value;
            }

            if (request.CategoryId.HasValue)
            {
                product.CategoryId = request.CategoryId.Value;
            }

            if (request.ProductTypeId.HasValue)
            {
                product.ProductTypeId = request.ProductTypeId.Value;
            }

            if (request.IsActive.HasValue)
            {
                product.IsActive = request.IsActive.Value;
            }

            await _repository.UpdateProductAsync(product);

            await _repository.SaveChangesAsync();

            return true;
        }
   public async Task<bool> DeleteProductAsync(int productId,int sellerId,int customerId)
        {
            var product = await _repository.GetProductForSellerCustomerAsync(productId,sellerId,customerId);
            if (product == null)
            {
                return false;
            }
            await _repository.DeleteProductAsync(product);
            await _repository.SaveChangesAsync();
            return true;
        }

    }
}