using Marketplacesellerportal.AuthManagement.DTOs;

namespace Marketplacesellerportal.AuthManagement.Interfaces
{
    public interface IAuthManagementService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);

        Task<LoginResponse> RegisterAsync(RegisterRequest request);

        Task<UserResponse?> GetCurrentUserAsync(int userId);

        Task<LoginResponse> ChangePasswordAsync(ChangePasswordRequest request);

        Task<LoginResponse> ForgotPasswordAsync(ForgotPasswordRequest request);

        Task<LoginResponse> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
