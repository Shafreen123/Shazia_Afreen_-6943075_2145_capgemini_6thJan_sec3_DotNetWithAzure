using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;


namespace StudentManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Students
    [HttpGet]
    public ActionResult<IEnumerable<StudentReadDTO>> GetStudents()
    {
        var students = _context.Students.ToList();

        var result = students.Select(s => new StudentReadDTO
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email
            // Password NOT included - safe!
        });

        return Ok(result);
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public ActionResult<StudentReadDTO> GetStudent(int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
            return NotFound($"Student with ID {id} not found.");

        var dto = new StudentReadDTO
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email
        };

        return Ok(dto);
    }

    // POST: api/Students
    [HttpPost]
    public ActionResult<StudentReadDTO> CreateStudent(StudentCreateDTO dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,  // Stored in DB
            CreatedAt = DateTime.Now
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        // Return ReadDTO — Password NOT exposed in response!
        var readDto = new StudentReadDTO
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email
        };

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, readDto);
    }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, StudentUpdateDTO dto)
    {
        var student = _context.Students.Find(id);

        if (student == null)
            return NotFound($"Student with ID {id} not found.");

        student.Name = dto.Name;
        student.Email = dto.Email;
        // Password NOT updated here — separate endpoint needed for that

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
            return NotFound($"Student with ID {id} not found.");

        _context.Students.Remove(student);
        _context.SaveChanges();

        return NoContent();
    }
}