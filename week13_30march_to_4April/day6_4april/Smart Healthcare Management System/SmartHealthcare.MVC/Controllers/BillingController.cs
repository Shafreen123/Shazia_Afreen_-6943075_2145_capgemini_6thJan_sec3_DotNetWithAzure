using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Models;
using SmartHealthcare.MVC.Services.Interfaces;

namespace SmartHealthcare.MVC.Controllers
{
    public class BillingController : Controller
    {
        private readonly IApiService _api;
        public BillingController(IApiService api) { _api = api; }

        // Helper methods
        private bool IsLoggedIn() =>
            HttpContext.Session.GetString("JwtToken") != null;

        private string GetRole() =>
            HttpContext.Session.GetString("Role") ?? "";

        private int GetPatientId() =>
            HttpContext.Session.GetInt32("PatientId") ?? 0;

        // ── INDEX: List bills ──────────────────────────────────────────────
        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var role = GetRole();
            List<BillViewModel>? bills;

            if (role == "Patient")
            {
                var patientId = GetPatientId();
                bills = await _api.GetAsync<List<BillViewModel>>($"bills/patient/{patientId}");
            }
            else
            {
                // Admin and Doctor see all bills
                bills = await _api.GetAsync<List<BillViewModel>>("bills");
            }

            ViewBag.Role = role;
            return View(bills ?? new List<BillViewModel>());
        }

        // ── DETAILS: View one bill ─────────────────────────────────────────
        public async Task<IActionResult> Details(int id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var bill = await _api.GetAsync<BillViewModel>($"bills/{id}");
            if (bill == null) return NotFound();

            ViewBag.Role = GetRole();
            return View(bill);
        }

        // ── CREATE: Show form ──────────────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            var role = GetRole();
            if (role != "Admin" && role != "Doctor")
                return RedirectToAction("Index", "Home");

            // Load appointments so admin/doctor can pick one
            var appointments = await _api
                .GetAsync<List<AppointmentViewModel>>("appointments") ?? new();

            ViewBag.Appointments = appointments;
            return View(new CreateBillViewModel());
        }

        // ── CREATE: Handle form submission ─────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> Create(CreateBillViewModel model)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                ViewBag.Appointments = await _api
                    .GetAsync<List<AppointmentViewModel>>("appointments") ?? new();
                return View(model);
            }

            var result = await _api.PostAsync<BillViewModel>("bills", new
            {
                model.AppointmentId,
                model.Amount,
                model.Description
            });

            if (result == null)
            {
                ModelState.AddModelError("", "Failed to create bill. The appointment may already have a bill.");
                ViewBag.Appointments = await _api
                    .GetAsync<List<AppointmentViewModel>>("appointments") ?? new();
                return View(model);
            }

            TempData["Success"] = $"Bill created successfully! Bill #{result.Id}";
            return RedirectToAction("Index");
        }

        // ── MARK AS PAID ───────────────────────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> MarkPaid(int id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");
            if (GetRole() != "Admin") return Forbid();

            await _api.PatchAsync<BillViewModel>($"bills/{id}/status", new { Status = "Paid" });
            TempData["Success"] = "Bill marked as Paid.";
            return RedirectToAction("Index");
        }

        // ── CANCEL ─────────────────────────────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");
            if (GetRole() != "Admin") return Forbid();

            await _api.PatchAsync<BillViewModel>($"bills/{id}/status", new { Status = "Cancelled" });
            TempData["Success"] = "Bill cancelled.";
            return RedirectToAction("Index");
        }

        // ── DELETE ─────────────────────────────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Auth");
            if (GetRole() != "Admin") return Forbid();

            await _api.DeleteAsync($"bills/{id}");
            TempData["Success"] = "Bill deleted.";
            return RedirectToAction("Index");
        }
    }
}