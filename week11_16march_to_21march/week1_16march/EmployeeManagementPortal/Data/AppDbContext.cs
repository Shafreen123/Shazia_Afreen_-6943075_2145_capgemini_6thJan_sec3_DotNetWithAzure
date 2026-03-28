using Microsoft.EntityFrameworkCore;
using EmployeeManagementPortal.Models;

namespace EmployeeManagementPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}