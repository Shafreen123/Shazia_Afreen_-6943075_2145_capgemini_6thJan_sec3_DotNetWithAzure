using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Employee_Project_Management_System.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        // Navigation for many-to-many (via join entity)
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

    }
}
