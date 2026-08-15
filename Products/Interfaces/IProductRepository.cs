
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.Products.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetBySKUAsync(string sku);
        Task<IEnumerable<Product>> GetBySellerAsync(int sellerId);
        Task<IEnumerable<Product>> GetProductsBySellerCustomerAsync(int sellerId,int customerId);
       
    }
}
