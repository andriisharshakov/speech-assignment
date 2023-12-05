using CompanyApi.Application.Services;
using CompanyApi.Domain.Repositories;
using CompanyApi.Infrastructure;
using CompanyApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyApi.Application.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Register DbContext and repositories
            services.AddDbContext<CompanyApiDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }

        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DepartmentService>();
        }
    }
}
