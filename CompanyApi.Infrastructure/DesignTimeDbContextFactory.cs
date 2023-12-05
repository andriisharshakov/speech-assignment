using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace CompanyApi.Infrastructure
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CompanyApiDbContext>
    {
        public CompanyApiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ".\\..\\CompanyApi\\"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<CompanyApiDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return new CompanyApiDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
