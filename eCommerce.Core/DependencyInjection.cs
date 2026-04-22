using UserService.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using UserService.Core.Validators;
using UserService.Core.ServiceContracts;

namespace UserService.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds infrastructure-related services to the specified service collection.
        /// </summary>
        /// <param name="services">The service collection to which infrastructure services are added.</param>
        /// <param name="configuration">The application configuration used for core setup.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {

            //Register FluentValidation validators
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            // Register your core services here
            // For example:
            // services.AddScoped<IMyService, MyService >();
            services.AddTransient<IUserService, UserService.Core.Services.UserService>();

            return services;
        }
    }
}
