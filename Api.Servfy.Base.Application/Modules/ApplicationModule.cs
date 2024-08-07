

using Api.Servfy.Base.Application.Services;
using Api.Servfy.Base.Application.Services.Contracts;
using Api.Servfy.Base.Middleware;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Servfy.Base.Application.Modules
{
    public static class ApplicationServicesModule
    {
        public static IServiceCollection AddApplicationServicesModule(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            //Services
            services.AddScoped<IUserService, UserService>();

            return services;
        }


        
    }
}
