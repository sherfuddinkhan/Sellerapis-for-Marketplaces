using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.Products.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetBySKUAsync(string sku);
        Task<IEnumerable<Product>> GetBySellerAsync(int sellerId);
    }
}