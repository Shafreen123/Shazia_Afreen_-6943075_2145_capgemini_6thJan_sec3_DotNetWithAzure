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

        private int GetPatientId() =>
            HttpContext.Session.GetInt32("PatientId") ?? GetUserId();

        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

    var role = GetRole();
    List<AppointmentViewModel>? appts;

    if (role == "Patient")
    {
        appts = await _api.GetAsync<List<AppointmentViewModel>>(
            $"appointments/patient/{GetPatientId()}");
    }
    else if (role == "Doctor")
    {
        // Use DoctorId (from Doctors table), NOT UserId
        var doctorId = HttpContext.Session.GetInt32("DoctorId") ?? 0;
        appts = await _api.GetAsync<List<AppointmentViewModel>>(
            $"appointments/doctor/{doctorId}");
    }
    else
    {
        appts = await _api.GetAsync<List<AppointmentViewModel>>("appointments");
    }

    ViewBag.Role = role;
    return View(appts ?? new List<AppointmentViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var role = GetRole();

            ViewBag.Doctors  = await _api.GetAsync<List<DoctorViewModel>>("doctors") ?? new();
            ViewBag.Patients = await _api.GetAsync<List<PatientViewModel>>("patients") ?? new();
            ViewBag.Role     = role;

            var model = new CreateAppointmentViewModel();
            if (role == "Patient") model.PatientId = GetPatientId();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentViewModel model)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                ViewBag.Doctors  = await _api.GetAsync<List<DoctorViewModel>>("doctors") ?? new();
                ViewBag.Patients = await _api.GetAsync<List<PatientViewModel>>("patients") ?? new();
                ViewBag.Role     = GetRole();
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
            await _api.PatchAsync<AppointmentViewModel>(
                $"appointments/{id}/status", new { Status = status });
            return RedirectToAction("Index");
        }
    }
}