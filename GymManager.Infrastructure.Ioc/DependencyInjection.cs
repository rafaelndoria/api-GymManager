using GymManager.Application.Services.Implementations;
using GymManager.Application.Services.Interfaces;
using GymManager.Core.Interfaces;
using GymManager.Infrastructure.Context;
using GymManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Context
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<IAuthService>());

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPlanService, PlanService>();

            return services;
        }
    }
}
