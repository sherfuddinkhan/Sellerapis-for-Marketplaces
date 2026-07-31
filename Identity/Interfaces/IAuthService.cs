using Marketplacesellerportal.Identity.DTOs;

namespace Marketplacesellerportal.Identity.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

        Task<bool> RegisterAsync(RegisterRequestDto request);
    }
}
