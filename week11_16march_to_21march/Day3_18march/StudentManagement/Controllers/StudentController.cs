using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
     
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id=1, Name="Raj Kumar", Email="raj@email.com",
                          Course="C# Programming", JoiningDate=DateTime.Now.AddDays(-30) },
            new Student { Id=2, Name="Priya Sharma", Email="priya@email.com",
                          Course="Web Development", JoiningDate=DateTime.Now.AddDays(-15) }
        };
        private static int _nextId = 3;

        public IActionResult Index()
        {
            return View(_students);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Add new student (POST - saves data)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = _nextId++;
                _students.Add(student);
                TempData["Success"] = "Student added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

      
        public IActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                var existing = _students.FirstOrDefault(s => s.Id == id);
                if (existing == null) return NotFound();
                existing.Name = student.Name;
                existing.Email = student.Email;
                existing.Course = student.Course;
                existing.JoiningDate = student.JoiningDate;
                TempData["Success"] = "Student updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            _students.Remove(student);
            TempData["Success"] = "Student deleted!";
            return RedirectToAction(nameof(Index));
        }
    }
}
