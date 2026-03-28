using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Project_Management_System.Data;
using Employee_Project_Management_System.Models;

namespace Employee_Project_Management_System.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(ep => ep.Project)
                .ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Projects = new MultiSelectList(
                _context.Projects, "ProjectId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, int[] selectedProjects)
        {
            // Remove navigation property errors from ModelState
            ModelState.Remove("Department");
            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                foreach (var pid in selectedProjects)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        EmployeeId = employee.EmployeeId,
                        ProjectId = pid,
                        AssignedDate = DateTime.Now
                    });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(
                _context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Projects = new MultiSelectList(
                _context.Projects, "ProjectId", "Title");
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeProjects)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null) return NotFound();

            var assignedIds = employee.EmployeeProjects
                .Select(ep => ep.ProjectId);
            ViewBag.Departments = new SelectList(
                _context.Departments, "DepartmentId", "DepartmentName",
                employee.DepartmentId);
            ViewBag.Projects = new MultiSelectList(
                _context.Projects, "ProjectId", "Title", assignedIds);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee, int[] selectedProjects)
        {
            if (id != employee.EmployeeId) return NotFound();

            ModelState.Remove("Department");
            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Update(employee);

                var existing = _context.EmployeeProjects
                    .Where(ep => ep.EmployeeId == id);
                _context.EmployeeProjects.RemoveRange(existing);

                foreach (var pid in selectedProjects)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        EmployeeId = id,
                        ProjectId = pid,
                        AssignedDate = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(
                _context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Projects = new MultiSelectList(
                _context.Projects, "ProjectId", "Title");
            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null) _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}