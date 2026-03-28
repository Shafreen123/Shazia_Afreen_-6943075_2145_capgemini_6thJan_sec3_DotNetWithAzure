using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null)
                return RedirectToAction("Dashboard");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", "Administrator");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials. Try admin / admin123";
            return View();
        }

        public IActionResult Dashboard()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login");

            ViewBag.Username = username;
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["LogoutMessage"] = "Logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}