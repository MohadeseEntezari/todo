using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Application.Common.Mappings
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            Type[] types =
            {
            typeof(ToDoTaskProfile),
        };
            services.AddAutoMapper(types);
        }
    }
}
