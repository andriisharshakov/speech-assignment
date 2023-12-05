using Microsoft.EntityFrameworkCore;

using CompanyApi.Domain.Entities;

namespace CompanyApi.Infrastructure
{
    public class CompanyApiDbContext : DbContext
    {
        public CompanyApiDbContext(DbContextOptions<CompanyApiDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
