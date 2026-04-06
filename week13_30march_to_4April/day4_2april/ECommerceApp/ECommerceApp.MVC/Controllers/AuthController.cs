using System.Text;
using System.Text.Json;
using ECommerceApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Auth/Login
        public IActionResult Login() => View();

        // POST: /Auth/Login
        // POST: /Auth/Login
[HttpPost]
public async Task<IActionResult> Login(LoginViewModel model)
{
    if (!ModelState.IsValid) return View(model);

    var client = _httpClientFactory.CreateClient("API");
    var json = JsonSerializer.Serialize(new { email = model.Email, password = model.Password });
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await client.PostAsync("api/auth/login", content);

    if (response.IsSuccessStatusCode)
    {
        var result = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(result);

        // ✅ Use exact property names from AuthResponseDto
        var token = doc.RootElement.GetProperty("token").GetString();
        var role  = doc.RootElement.GetProperty("role").GetString();
        var name  = doc.RootElement.GetProperty("name").GetString();

        HttpContext.Session.SetString("JwtToken", token!);
        HttpContext.Session.SetString("UserRole", role!);
        HttpContext.Session.SetString("UserName", name!);

        return RedirectToAction("Index", "Product");
    }

    ModelState.AddModelError("", "Invalid email or password.");
    return View(model);
}
        // GET: /Auth/Register
        public IActionResult Register() => View();

        // POST: /Auth/Register
        // POST: /Auth/Register
[HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (!ModelState.IsValid) return View(model);

    var client = _httpClientFactory.CreateClient("API");
    var json = JsonSerializer.Serialize(new
    {
        firstName   = model.FirstName,
        lastName    = model.LastName,
        email       = model.Email,
        password    = model.Password,
        phoneNumber = model.PhoneNumber
    });
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await client.PostAsync("api/auth/register", content);

    if (response.IsSuccessStatusCode)
        return RedirectToAction("Login");

    var error = await response.Content.ReadAsStringAsync();
    ModelState.AddModelError("", "Registration failed. Email may already be in use.");
    return View(model);
}
        // GET: /Auth/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}