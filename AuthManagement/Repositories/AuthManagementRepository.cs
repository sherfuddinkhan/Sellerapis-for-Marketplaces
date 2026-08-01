using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.AuthManagement.Interfaces;

namespace Marketplacesellerportal.AuthManagement.Repositories
{
    public class AuthManagementRepository : IAuthManagementRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthManagementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Login

        public async Task<User?> LoginAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserId == userId);
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

        #endregion

        #region Registration

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await _context.Users
                .AnyAsync(x => x.UserName == userName);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(x => x.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        #endregion

        #region Update

        public Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task UpdatePasswordAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task UpdateLastLoginAsync(User user)
        {
            user.LastLoginDate = DateTime.Now;
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task UpdateFailedLoginAttemptsAsync(User user)
        {
            user.FailedLoginAttempts = user.FailedLoginAttempts + 1;

            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task ResetFailedLoginAttemptsAsync(User user)
        {
            user.FailedLoginAttempts = 0;
            user.IsLocked = false;

            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        #endregion

        #region Password Reset

        public Task SetPasswordResetTokenAsync(
            User user,
            string token,
            DateTime expiry)
        {
            user.PasswordResetToken = token;
            user.PasswordResetExpiry = expiry;

            _context.Users.Update(user);

            return Task.CompletedTask;
        }

        public async Task<User?> GetByResetTokenAsync(string token)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.PasswordResetToken == token &&
                    x.PasswordResetExpiry >= DateTime.Now);
        }

        #endregion

        #region Lock / Unlock

        public Task LockUserAsync(User user)
        {
            user.IsLocked = true;

            _context.Users.Update(user);

            return Task.CompletedTask;
        }

        public Task UnlockUserAsync(User user)
        {
            user.IsLocked = false;
            user.FailedLoginAttempts = 0;

            _context.Users.Update(user);

            return Task.CompletedTask;
        }

        #endregion

        #region Save

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
