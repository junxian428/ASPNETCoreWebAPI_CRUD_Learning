using Microsoft.EntityFrameworkCore;

namespace reactjscrud.Models
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }


    }
}
