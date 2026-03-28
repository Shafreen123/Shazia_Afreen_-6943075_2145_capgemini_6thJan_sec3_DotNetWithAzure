using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Project_Management_System.Data;
using Employee_Project_Management_System.Models;

namespace Employee_Project_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                .ToListAsync();
            return View(projects);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = new MultiSelectList(
                _context.Employees, "EmployeeId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project, int[] selectedEmployees)
        {
            // Remove navigation property errors from ModelState
            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                foreach (var eid in selectedEmployees)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        ProjectId = project.ProjectId,
                        EmployeeId = eid,
                        AssignedDate = DateTime.Now
                    });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = new MultiSelectList(
                _context.Employees, "EmployeeId", "FullName");
            return View(project);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.Projects
                .Include(p => p.EmployeeProjects)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null) return NotFound();

            var assignedIds = project.EmployeeProjects
                .Select(ep => ep.EmployeeId);
            ViewBag.Employees = new MultiSelectList(
                _context.Employees, "EmployeeId", "FullName", assignedIds);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project, int[] selectedEmployees)
        {
            if (id != project.ProjectId) return NotFound();

            ModelState.Remove("EmployeeProjects");

            if (ModelState.IsValid)
            {
                _context.Update(project);

                var existing = _context.EmployeeProjects
                    .Where(ep => ep.ProjectId == id);
                _context.EmployeeProjects.RemoveRange(existing);

                foreach (var eid in selectedEmployees)
                {
                    _context.EmployeeProjects.Add(new EmployeeProject
                    {
                        ProjectId = id,
                        EmployeeId = eid,
                        AssignedDate = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = new MultiSelectList(
                _context.Employees, "EmployeeId", "FullName");
            return View(project);
        }

        public async Task<IActionResult> Dashboard()
        {
            var projects = await _context.Projects
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                        .ThenInclude(e => e.Department)
                .ToListAsync();
            return View(projects);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null) return NotFound();
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null) _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}