using BookingService.DataAccess.Models;
using BookingService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.DataAccess.Extensions
{
    /// <summary>
    /// configure the services from the data layer
    /// </summary>
    public static class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Function to add the context services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="options">The options of the context</param>
        /// <returns>A<see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddBookingDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services
                .AddDbContext<OrderContext>(options)
                .AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<OrderContext>().Set<Order>());

            return services;
        }

        /// <summary>
        /// Function to add repositories to the services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
