using Marketplacesellerportal.AuthManagement.DTOs;
using Marketplacesellerportal.AuthManagement.Helpers;
using Marketplacesellerportal.AuthManagement.Interfaces;
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.AuthManagement.Services
{
    public class AuthManagementService : IAuthManagementService
    {
        private readonly IAuthManagementRepository _repository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthManagementService(
            IAuthManagementRepository repository,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        #region Register

        public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
        {
            // Check username
            if (await _repository.UserExistsAsync(request.UserName))
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Username already exists."
                };
            }

            // Check email
            if (await _repository.EmailExistsAsync(request.Email))
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Email already exists."
                };
            }

            // Validate Customer belongs to Seller
            if (request.CustomerId.HasValue)
            {
                var customerExists =
                    await _repository.CustomerBelongsToSellerAsync(
                        request.CustomerId.Value,
                        request.SellerId);

                if (!customerExists)
                {
                    return new LoginResponse
                    {
                        Success = false,
                        Message = "Customer does not belong to the specified seller."
                    };
                }
            }

            // Create User
            var user = new User
            {
                SellerId = request.SellerId,
                CustomerId = request.CustomerId,
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
                Mobile = request.Mobile,
                Role = request.Role,
                PasswordHash = PasswordHasher.Hash(request.Password),
                IsActive = true,
                EmailVerified = false,
                MobileVerified = false,
                FailedLoginAttempts = 0,
                IsLocked = false,

                CreatedDate = DateTime.Now
            };

            // Save
            await _repository.AddUserAsync(user);
            await _repository.SaveChangesAsync();

            // Return registered user details
            return new LoginResponse
            {
                Success = true,
                Message = "User registered successfully.",
                UserId = user.UserId,
                SellerId = user.SellerId,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Role = user.Role ?? ""
            };
        }

        #endregion

        #region Login

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _repository.LoginAsync(request.UserName);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password."
                };
            }

            if (user.IsLocked)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Account is locked."
                };
            }

            if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
            {
                await _repository.UpdateFailedLoginAttemptsAsync(user);

                if (user.FailedLoginAttempts >= 5)
                    await _repository.LockUserAsync(user);

                await _repository.SaveChangesAsync();

                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password."
                };
            }

            await _repository.ResetFailedLoginAttemptsAsync(user);
            await _repository.UpdateLastLoginAsync(user);
            await _repository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginResponse
            {
                Success = true,
                Message = "Login successful.",
                Token = token.token,
                Expiration = token.expiration,
                UserId = user.UserId,
                SellerId = user.SellerId,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Role = user.Role ?? ""
            };
        }

        #endregion

        #region Current User

        public async Task<UserResponse?> GetCurrentUserAsync(int userId)
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user == null)
                return null;

            return new UserResponse
            {
                UserId = user.UserId,
                SellerId = user.SellerId,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email ?? "",
                Mobile = user.Mobile ?? "",
                Role = user.Role ?? "",
                IsActive = user.IsActive
            };
        }

        #endregion

        #region Change Password

        public async Task<LoginResponse> ChangePasswordAsync(
     ChangePasswordRequest request)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            if (!PasswordHasher.Verify(
                request.CurrentPassword,
                user.PasswordHash))
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Current password is incorrect."
                };
            }

            user.PasswordHash =
                PasswordHasher.Hash(request.NewPassword);

            user.UpdatedDate = DateTime.Now;

            await _repository.UpdatePasswordAsync(user);
            await _repository.SaveChangesAsync();

            return new LoginResponse
            {
                Success = true,
                Message = "Password changed successfully.",
                UserId = user.UserId,
                SellerId = user.SellerId,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Role = user.Role ?? ""
            };
        }

        #endregion

        #region Forgot Password

        public async Task<LoginResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _repository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Email not found."
                };
            }

            var token = Guid.NewGuid().ToString();

            await _repository.SetPasswordResetTokenAsync(
                user,
                token,
                DateTime.Now.AddHours(1));

            await _repository.SaveChangesAsync();

            return new LoginResponse
            {
                Success = true,
                Message = "Password reset token generated successfully.",
                Token = token,
                UserId = user.UserId,
                SellerId = user.SellerId,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Role = user.Role ?? ""
            };
        }

        #endregion

        #region Reset Password

        public async Task<LoginResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _repository.GetByResetTokenAsync(request.Token);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid or expired token."
                };
            }

            user.PasswordHash = PasswordHasher.Hash(request.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetExpiry = null;

            await _repository.UpdatePasswordAsync(user);
            await _repository.SaveChangesAsync();

            return new LoginResponse

            {
                Success = true,
                Message = "Password reset token generated successfully.",
                UserId = user.UserId,
                SellerId = user.SellerId,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Role = user.Role ?? ""
            };
        }

        #endregion
    }
}
