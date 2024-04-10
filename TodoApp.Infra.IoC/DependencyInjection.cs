
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Interfaces;
using TodoApp.Infra.Data.Repositories;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Services;

namespace TodoApp.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            ));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();


            return services;
        }
    }
}
