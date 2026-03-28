using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // HOME PAGE — shows all students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: Registration Form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Save Student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _context.Students.Add(student);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Student '{student.Name}' registered successfully!";
            return RedirectToAction("Index"); // ← goes to table after saving
        }
    }
}