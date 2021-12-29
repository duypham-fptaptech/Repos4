using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assigment1.Models;

namespace Assigment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assigment1.Models.Product> Product { get; set; }
        public DbSet<Assigment1.Models.Category> Category { get; set; }
    }
}