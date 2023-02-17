using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SenderService.Consumer.Consumer;
using SenderService.Consumer.Sender;

namespace SenderService.Consumer.Extensions
{
    /// <summary>
    /// Coniguration of services
    /// </summary>
    public static partial class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Configure the services 
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>Services</returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services
                .AddScoped<ISenderMessage, SenderEmail>()
                .AddHostedService<OrderConsumer>();

            return services;
        }
    }
}
