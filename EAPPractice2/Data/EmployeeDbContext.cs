using Microsoft.EntityFrameworkCore;
using EAPPractice2.Models;
namespace EAPPractice2.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options) { }

        public DbSet<Employee> employees => Set<Employee>();
    }
}
