using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Employee_Project_Management_System.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // FK to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Navigation for many-to-many (via join entity)
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

    }
}
