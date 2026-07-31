using Marketplacesellerportal.Database;
using Marketplacesellerportal.Identity.DTOs;
using Marketplacesellerportal.Identity.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Identity.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> RegisterAsync(RegisterRequestDto request)
        {
            var user = new User
            {
                SellerId = request.SellerId,
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
                Mobile = request.Mobile,
                PasswordHash = request.Password,
                Role = request.Role,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
