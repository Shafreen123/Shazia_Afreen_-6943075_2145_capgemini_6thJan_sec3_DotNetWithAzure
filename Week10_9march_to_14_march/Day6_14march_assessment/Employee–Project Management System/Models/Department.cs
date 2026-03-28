using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Employee_Project_Management_System.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required, MaxLength(100)]
        public string DepartmentName { get; set; }

        // Navigation: one department -> many employees
        public ICollection<Employee> Employees { get; set; }

    }
}
