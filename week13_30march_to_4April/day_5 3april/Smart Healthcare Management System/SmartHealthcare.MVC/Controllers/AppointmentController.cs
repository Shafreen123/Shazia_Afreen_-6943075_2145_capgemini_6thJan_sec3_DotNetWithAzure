using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Models;
using SmartHealthcare.MVC.Services.Interfaces;

namespace SmartHealthcare.MVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IApiService _api;
        public AppointmentController(IApiService api) { _api = api; }

        private bool IsLoggedIn() =>
            HttpContext.Session.GetString("JwtToken") != null;

        private string GetRole() =>
            HttpContext.Session.GetString("Role") ?? "";

        private int GetUserId() =>
            HttpContext.Session.GetInt32("UserId") ?? 0;

        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var role   = GetRole();
            var userId = GetUserId();
            List<AppointmentViewModel>? appts;

            if (role == "Patient")
                appts = await _api.GetAsync<List<AppointmentViewModel>>($"appointments/patient/{userId}");
            else if (role == "Doctor")
                appts = await _api.GetAsync<List<AppointmentViewModel>>($"appointments/doctor/{userId}");
            else
                appts = await _api.GetAsync<List<AppointmentViewModel>>("appointments");

            ViewBag.Role = role;
            return View(appts ?? new List<AppointmentViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var role   = GetRole();
            var userId = GetUserId();

            ViewBag.Doctors      = await _api.GetAsync<List<DoctorViewModel>>("doctors") ?? new();
            ViewBag.Patients     = await _api.GetAsync<List<PatientViewModel>>("patients") ?? new();
            ViewBag.Role         = role;
            ViewBag.DoctorUserId = userId;

            var model = new CreateAppointmentViewModel();
            if (role == "Patient") model.PatientId = userId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentViewModel model)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                var role   = GetRole();
                var userId = GetUserId();
                ViewBag.Doctors      = await _api.GetAsync<List<DoctorViewModel>>("doctors") ?? new();
                ViewBag.Patients     = await _api.GetAsync<List<PatientViewModel>>("patients") ?? new();
                ViewBag.Role         = role;
                ViewBag.DoctorUserId = userId;
                return View(model);
            }

            await _api.PostAsync<AppointmentViewModel>("appointments", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");
            if (GetRole() != "Doctor" && GetRole() != "Admin") return Forbid();

            var appt = await _api.GetAsync<AppointmentViewModel>($"appointments/{id}");
            if (appt == null) return NotFound();
            return View(appt);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");
            await _api.PatchAsync<AppointmentViewModel>($"appointments/{id}/status", new { Status = status });
            return RedirectToAction("Index");
        }
    }
}
