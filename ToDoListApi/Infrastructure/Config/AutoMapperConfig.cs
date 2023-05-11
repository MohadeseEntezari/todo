using ToDoListApi.Infrastructure.Mapper;

namespace ToDoListApi.Infrastructure.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            Type[] types =
            {
            typeof(UserProfile),
            typeof(ToDoTaskProfile),
        };
            services.AddAutoMapper(types);
        }
    }
}
