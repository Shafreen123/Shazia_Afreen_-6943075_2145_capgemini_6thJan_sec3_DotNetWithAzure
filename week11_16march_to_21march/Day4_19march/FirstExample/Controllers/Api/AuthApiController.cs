using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthApiController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtTokenService _jwtService;

    public AuthApiController(UserManager<ApplicationUser> userManager,
                             JwtTokenService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    // POST /api/authapi/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] ApiLoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return Unauthorized(new { message = "Invalid credentials" });

        var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isValid) return Unauthorized(new { message = "Invalid credentials" });

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtService.GenerateToken(user, roles);

        return Ok(new ApiLoginResponse
        {
            Success = true,
            Token = token,
            Expires = DateTime.UtcNow.AddMinutes(60),
            Message = $"Welcome, {user.FullName}!"
        });
    }

    // GET /api/authapi/profile  (Protected by JWT)
    [Authorize(AuthenticationSchemes = "JwtScheme")]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId!);
        return Ok(new
        {
            user!.FullName,
            user.Email,
            user.StudentId,
            user.EnrollmentDate
        });

    }

    // GET /api/authapi/admin  (JWT + Admin role)
    [Authorize(AuthenticationSchemes = "JwtScheme", Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly()
    {
        return Ok(new { message = "Welcome, Admin! JWT verified." });
    }
}
