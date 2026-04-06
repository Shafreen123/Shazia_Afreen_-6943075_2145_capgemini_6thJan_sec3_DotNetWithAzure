using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ECommerceApp.Core.DTOs.Auth;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceApp.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            // Check if email already exists
            if (await _userRepo.EmailExistsAsync(dto.Email))
                throw new Exception("Email already registered");

            // Create new user with hashed password
            var user = new User
            {
                Name  = dto.FirstName + " " + dto.LastName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role  = "User"
            };

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();

            return GenerateAuthResponse(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            // Find user by email
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            // Verify password
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            return GenerateAuthResponse(user);
        }

        // -- Private Helpers -------------------------------------------

        private AuthResponseDto GenerateAuthResponse(User user)
        {
            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            return new AuthResponseDto
            {
                Token        = token,
                RefreshToken = refreshToken,
                Email        = user.Email,
                Name         = user.Name,
                Role         = user.Role,
                ExpiresAt    = DateTime.UtcNow.AddHours(2)
            };
        }

        private string GenerateJwtToken(User user)
        {
            // Claims = information stored inside the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key   = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:   _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims:   claims,
                expires:  DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(bytes);
        }

        private static string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        private static bool VerifyPassword(string password, string hash)
            => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
