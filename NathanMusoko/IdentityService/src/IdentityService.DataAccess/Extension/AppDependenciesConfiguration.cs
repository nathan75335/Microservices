using IdentityService.DataAccess.Models;
using IdentityService.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.DataAccess.Extension
{
    /// <summary>
    /// The applications services for the data Layer
    /// </summary>
    public static class AppDependenciesConfiguration
    {
        /// <summary>
        /// Function To Identity Confirguration to the services of the application
        /// </summary>
        /// <param name="services">The services of the app</param>
        /// <param name="options">Options to build the Database context</param>
        /// <returns>The services that we added <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddIdentityServiceConfigutation(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<IdentityContext>(options)
                .AddIdentity<User, Role>(opts =>
                {
                    opts.User.RequireUniqueEmail = true;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<IdentityContext>().Set<UserRefreshToken>());
            services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<IdentityContext>().Set<UserClaim>());
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserRefreshRepository, UserRefreshRepository>();
            services.AddScoped<ISaveChangesRepository, SaveChangesRepository>();

            return services;
        }
    }
}
