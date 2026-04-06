using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Models;
using SmartHealthcare.MVC.Services.Interfaces;

namespace SmartHealthcare.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiService _api;
        public AuthController(IApiService api) { _api = api; }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _api.PostAsync<AuthResponseViewModel>("auth/login", new
            {
                model.Email,
                model.Password
            });

            if (result == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // Save core session values first
            HttpContext.Session.SetString("JwtToken", result.Token);
            HttpContext.Session.SetString("Username", result.Username);
            HttpContext.Session.SetString("Role",     result.Role);
            HttpContext.Session.SetInt32("UserId",    result.UserId);

            // Set token before any further API calls
            _api.SetToken(result.Token);

            if (result.Role == "Patient")
            {
                var patient = await _api.GetAsync<PatientViewModel>(
                    $"patients/byuser/{result.UserId}");

                if (patient != null)
                    HttpContext.Session.SetInt32("PatientId", patient.Id);
                else
                    Console.WriteLine("[LOGIN] Patient profile not found for UserId=" + result.UserId);
            }
            else if (result.Role == "Doctor")   // ← now a proper sibling block, not nested
            {
                var doctors = await _api.GetAsync<List<DoctorViewModel>>("doctors");
                var match   = doctors?.FirstOrDefault(d =>
                    d.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase));

                if (match != null)
                {
                    HttpContext.Session.SetInt32("DoctorId", match.Id);
                    Console.WriteLine("[LOGIN] DoctorId=" + match.Id + " saved to session");
                }
                else
                    Console.WriteLine("[LOGIN] Doctor profile not found for email=" + model.Email);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _api.PostAsync<AuthResponseViewModel>("auth/register", new
            {
                model.Username,
                model.Email,
                model.Password,
                model.Role
            });

            if (result == null)
            {
                ModelState.AddModelError("", "Registration failed. Email may already be in use.");
                return View(model);
            }

            HttpContext.Session.SetString("JwtToken", result.Token);
            HttpContext.Session.SetString("Username", result.Username);
            HttpContext.Session.SetString("Role",     result.Role);
            HttpContext.Session.SetInt32("UserId",    result.UserId);

            _api.SetToken(result.Token);

            if (result.Role == "Patient")
            {
                var patientResult = await _api.PostAsync<PatientViewModel>("patients", new
                {
                    FullName    = model.Username,
                    Phone       = "0000000000",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Gender      = "Other",
                    Address     = "",
                    UserId      = result.UserId
                });

                if (patientResult != null)
                    HttpContext.Session.SetInt32("PatientId", patientResult.Id);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}