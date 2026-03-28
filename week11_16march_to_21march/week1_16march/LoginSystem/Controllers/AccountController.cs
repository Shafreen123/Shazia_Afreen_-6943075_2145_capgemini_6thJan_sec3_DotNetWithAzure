using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in skip login page
            if (HttpContext.Session.GetString("Username") != null)
                return RedirectToAction("Dashboard");

            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                // Save username in session
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", "Administrator");
                return RedirectToAction("Dashboard");
            }

            // Wrong credentials
            ViewBag.Error = "Invalid username or password. Try admin / 123";
            return View();
        }

        // GET: /Account/Dashboard
        public IActionResult Dashboard()
        {
            // Check session — if not logged in go back to login
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login");

            ViewBag.Username = username;
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // destroy session
            TempData["LogoutMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}