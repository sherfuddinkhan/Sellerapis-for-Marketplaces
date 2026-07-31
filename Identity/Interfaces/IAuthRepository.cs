using Marketplacesellerportal.Identity.DTOs;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Identity.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByUserNameAsync(string userName);

        Task<User?> GetByEmailAsync(string email);

        Task<User> RegisterAsync(RegisterRequestDto request);

        Task UpdateAsync(User user);
    }
}
