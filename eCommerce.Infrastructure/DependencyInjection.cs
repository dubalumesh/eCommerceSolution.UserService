using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds infrastructure-related services to the specified service collection.
        /// </summary>
        /// <param name="services">The service collection to which infrastructure services are added.</param>
        /// <param name="configuration">The application configuration used for infrastructure setup.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your infrastructure services here
            // For example:
            // services.AddScoped<IMyRepository, MyRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<DapperDbContext>();
            return services;
        }
    }
}
