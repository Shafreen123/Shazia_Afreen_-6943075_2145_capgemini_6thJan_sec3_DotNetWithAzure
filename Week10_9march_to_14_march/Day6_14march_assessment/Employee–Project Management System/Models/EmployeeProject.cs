using System;
using System.ComponentModel.DataAnnotations;


namespace Employee_Project_Management_System.Models
{
    public class EmployeeProject
    {
        // Composite primary key configured via Fluent API
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        // Extra field required by the spec
        [Required]
        public DateTime AssignedDate { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public Project Project { get; set; }

    }
}
