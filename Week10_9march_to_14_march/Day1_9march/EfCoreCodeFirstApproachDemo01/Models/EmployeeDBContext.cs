using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirstApproachDemo01.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}