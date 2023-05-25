using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContextDb>(opt => opt.UseInMemoryDatabase("ToDoTaskDB"));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContextDb>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddScoped<IApplicationContextDb, ApplicationContextDb>();
            return services;
        }
    }
}
