using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Common.Mappings;

namespace ToDo.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapperConfiguration();
            return services;

        }
    }
}
