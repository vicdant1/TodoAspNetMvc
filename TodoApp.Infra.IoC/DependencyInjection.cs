
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Services;using TodoApp.Domain.Identity;
using TodoApp.Domain.Interfaces;
using TodoApp.Infra.Data.Context;
using TodoApp.Infra.Data.Repositories;

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

            
            services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.User.RequireUniqueEmail = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                //Location for your Custom Access Denied Page
                options.AccessDeniedPath = "/Account/AccessDenied";

                //Location for your Custom Login Page
                options.LoginPath = "/Account";
            });

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
