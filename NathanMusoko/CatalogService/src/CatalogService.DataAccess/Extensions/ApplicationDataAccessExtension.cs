using CatalogService.DataAccess.Models;
using CatalogService.DataAccess.Repositories;
using CatalogService.DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.DataAccess.Extensions
{
    /// <summary>
    /// The application data access layer services
    /// </summary>
    public static partial class ApplicationDataAccessExtension
    {
        /// <summary>
        /// Function to add the service of the data Layer
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="options">The options of the datbase</param>
        /// <returns></returns>
        public static IServiceCollection AddCatalogDbContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<BookContext>(options);

            services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<BookContext>().Set<Book>());
            services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<BookContext>().Set<EditionHouse>());
            services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<BookContext>().Set<Genre>());

            return services;
        }

        /// <summary>
        /// Function to add repositories to the services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IEditionHouseRepository, EditionHouseRepository>()
                .AddScoped<ISaveChangesRepository, SaveChangesRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddTransient<SeedGenres>();
        }
    }
}
