using Marketplacesellerportal.AuthManagement.DTOs;
using Marketplacesellerportal.AuthManagement.Interfaces;
using Marketplacesellerportal.AuthManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.AuthManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthManagementController : ControllerBase
    {
        private readonly IAuthManagementService _service;

        public AuthManagementController(IAuthManagementService service)
        {
            _service = service;
        }

        // POST: api/AuthManagement/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _service.RegisterAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/AuthManagement/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _service.LoginAsync(request);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        // GET: api/AuthManagement/me
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            var result = await _service.GetCurrentUserAsync(userId);

            return Ok(result);
        }

        // POST: api/AuthManagement/logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new
            {
                Success = true,
                Message = "Logged out successfully."
            });
        }

        // POST: api/AuthManagement/change-password
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var result = await _service.ChangePasswordAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/AuthManagement/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var result = await _service.ForgotPasswordAsync(request);

            return Ok(result);
        }

        // POST: api/AuthManagement/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var result = await _service.ResetPasswordAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
