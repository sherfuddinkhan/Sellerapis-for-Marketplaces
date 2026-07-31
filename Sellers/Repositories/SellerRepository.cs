using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Repositories;
using Marketplacesellerportal.Sellers.Interfaces;

namespace Marketplacesellerportal.Sellers.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Seller?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> ExistsAsync(int sellerId)
        {
            return await _dbSet.AnyAsync(x => x.SellerId == sellerId);
        }
    }
}
