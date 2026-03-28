using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Controllers
{
    public class HRController : Controller
    {
        private readonly AppDbContext _context;

        public HRController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            ViewBag.TotalEmployees = _context.Employees.Count();
            return View();
        }

        public IActionResult EmployeeList()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Reports()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            // Uncomment to test exception filter:
            // throw new Exception("Reports module under maintenance!");

            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.GeneratedAt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            return View();
        }
    }
}
