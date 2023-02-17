using CatalogService.DataAccess;
using CatalogService.DataAccess.SeedData;

namespace CatalogService.Api.Extensions
{
    /// <summary>
    /// Coniguration of the database by adding seed data
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Function to add seed data as a service
        /// </summary>
        /// <param name="app"><The <see cref="IApplicationBuilder"/>/param>
        /// <returns> A <see cref="IApplicationBuilder"/></returns>
        public static async void InitializeDatabase(this WebApplication app)
        {
            var scopedFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                var migrateService = scope.ServiceProvider.GetRequiredService<BookContext>();
                await migrateService.Database.EnsureCreatedAsync();
                var service = scope.ServiceProvider.GetRequiredService<SeedGenres>();
                await service.SeedDataAsync(default);
            }
        }
    }
}
