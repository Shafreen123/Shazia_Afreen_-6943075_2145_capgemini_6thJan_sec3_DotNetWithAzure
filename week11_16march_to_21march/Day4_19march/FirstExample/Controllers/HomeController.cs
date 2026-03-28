using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // Public - anyone can see
    public IActionResult Index() => View();

    // Protected - must be logged in
    [Authorize]
    public async Task<IActionResult> Dashboard()
    {
        var user = await _userManager.GetUserAsync(User);
        var roles = await _userManager.GetRolesAsync(user!);
        ViewBag.UserName = user?.FullName ?? user?.Email;
        ViewBag.Roles = string.Join(", ", roles);
        ViewBag.StudentId = user?.StudentId;
        return View();
    }

    // Admin only
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminPanel()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    // Multi-role access
    [Authorize(Roles = "Admin,Teacher")]
    public IActionResult TeacherDashboard() => View();
}

