using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductImages.Interfaces
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetAllAsync();

        Task<ProductImage?> GetByIdAsync(int productImageId);

        Task<IEnumerable<ProductImage>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductImage>> GetPrimaryImagesAsync();

        Task<ProductImage?> GetPrimaryImageAsync(int productId);

        Task AddAsync(ProductImage productImage);

        Task UpdateAsync(ProductImage productImage);

        Task DeleteAsync(int productImageId);

        Task SaveChangesAsync();
    }
}
