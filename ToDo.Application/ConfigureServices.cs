using FluentValidation;
using MediatR;
using MediatrTutorial.Infrastructure.Behaviours;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Common.Authentication;
using ToDo.Application.Common.Mappings;

namespace ToDo.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));

            AssemblyScanner.FindValidatorsInAssembly(Assembly.Load("ToDo.Application"))
                .ForEach(result => { services.AddTransient(result.InterfaceType, result.ValidatorType); });

            services.AddAutoMapperConfiguration();

            services.AddScoped<IAuthorizationHandler, UserTaskAuthorizationHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("userTasks", policy =>
                    policy.Requirements.Add(new UserTaskRequirement()));
            });
            return services;

        }
    }
}
    