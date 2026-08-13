using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.AuthManagement.Interfaces
{
    public interface IAuthManagementRepository
    {
        // ==========================================
        // Authentication
        // ==========================================

        Task<User?> LoginAsync(string userName);

        Task<User?> GetByIdAsync(int userId);

        Task<User?> GetByUserNameAsync(string userName);

        Task<User?> GetByEmailAsync(string email);


        // ==========================================
        // Registration
        // ==========================================

        Task<bool> SellerExistsAsync(int sellerId);

        Task<bool> UserExistsAsync(string userName);

        Task<bool> EmailExistsAsync(string email);

        Task AddUserAsync(User user);


        // ==========================================
        // Customer Validation
        // ==========================================

        Task<bool> CustomerBelongsToSellerAsync(
            int customerId,
            int sellerId);


        // ==========================================
        // Update
        // ==========================================

        Task UpdateUserAsync(User user);

        Task UpdatePasswordAsync(User user);

        Task UpdateLastLoginAsync(User user);

        Task UpdateFailedLoginAttemptsAsync(User user);

        Task ResetFailedLoginAttemptsAsync(User user);


        // ==========================================
        // Password Reset
        // ==========================================

        Task SetPasswordResetTokenAsync(
            User user,
            string token,
            DateTime expiry);

        Task<User?> GetByResetTokenAsync(string token);


        // ==========================================
        // Account Lock
        // ==========================================

        Task LockUserAsync(User user);

        Task UnlockUserAsync(User user);


        // ==========================================
        // Save
        // ==========================================

        Task SaveChangesAsync();
    }
}