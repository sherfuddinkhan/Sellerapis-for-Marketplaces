using Marketplacesellerportal.Identity.DTOs;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Identity.Interfaces
{
    public interface ITokenService
    {
        LoginResponseDto GenerateToken(User user);
    }
}
