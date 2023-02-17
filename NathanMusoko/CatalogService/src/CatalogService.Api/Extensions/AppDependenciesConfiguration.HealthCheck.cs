namespace CatalogService.Api.Extensions
{
    /// <summary>
    /// Configruation of the health check service
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Configure the healthcheck service
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddHealthCheck(this IServiceCollection services,
           IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("ConnectionString"));

            return services;
        }
    }
}
