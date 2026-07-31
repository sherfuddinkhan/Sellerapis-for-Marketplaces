using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductImages.Interfaces
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImage>> GetAllAsync();

        Task<ProductImage?> GetByIdAsync(int productImageId);

        Task<IEnumerable<ProductImage>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductImage>> GetPrimaryImagesAsync();

        Task<ProductImage?> GetPrimaryImageAsync(int productId);

        Task<ProductImage> CreateAsync(ProductImage productImage);

        Task<bool> UpdateAsync(int productImageId, ProductImage productImage);

        Task<bool> DeleteAsync(int productImageId);
    }
}
