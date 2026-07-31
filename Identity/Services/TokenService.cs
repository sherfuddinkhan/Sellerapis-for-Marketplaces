using Marketplacesellerportal.Configuration;
using Marketplacesellerportal.Identity.DTOs;
using Marketplacesellerportal.Identity.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.Extensions.Options;

namespace Marketplacesellerportal.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public LoginResponseDto GenerateToken(User user)
        {
            return new LoginResponseDto
            {
                Success = true,
                Message = "Token generation will be implemented next.",
                UserId = user.UserId,
                SellerId = user.SellerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                Token = "",
                Expiration = DateTime.UtcNow
            };
        }
    }
}