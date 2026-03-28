using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using ECommerceUserAPI.Data;
using ECommerceUserAPI.DTOs;
using ECommerceUserAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceUserAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    // POST: api/Auth/register
    [HttpPost("register")]
    public IActionResult Register(RegisterDTO dto)
    {
        // Check if email already exists
        if (_context.Users.Any(u => u.Email == dto.Email))
            return BadRequest("Email already registered.");

        // AutoMapper converts RegisterDTO → User
        var user = _mapper.Map<User>(dto);

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User Registered Successfully!");
    }

    // POST: api/Auth/login
    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

        if (user == null)
            return Unauthorized("Invalid email or password.");

        var token = GenerateToken(user);

        return Ok(new { token });
    }

    // GET: api/Auth/profile  (PROTECTED - needs JWT token)
    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        var email = User.Identity?.Name;

        var user = _context.Users.FirstOrDefault(x => x.Email == email);

        if (user == null)
            return NotFound("User not found.");

        // AutoMapper converts User → UserDTO (no Password!)
        var result = _mapper.Map<UserDTO>(user);

        return Ok(result);
    }

    // Private helper: Generate JWT Token
    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}