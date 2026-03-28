using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Protect route — must be logged in
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            var students = _context.Students.ToList();
            return View(students);
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
        public IActionResult Register(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _context.Students.Add(student);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Student '{student.Name}' registered!";
            return RedirectToAction("Index");
        }
    }
}