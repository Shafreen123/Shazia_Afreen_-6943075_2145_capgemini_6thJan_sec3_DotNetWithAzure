using Microsoft.AspNetCore.Mvc;
using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.Models;

namespace EmployeeManagementPortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            TempData["SuccessMessage"] =
                $"Employee '{employee.Name}' registered in {employee.Department}!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();
            return View(employee);
        }
    }
}