using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess
{
    /// <summary>
    /// The book database context of the application
    /// </summary>
    public class BookContext : DbContext
    { 
        /// <summary>
        ///  Initializes an instance of <see cref="BookContext"/>
        /// </summary>
        /// <param name="options"></param>
        public BookContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Function to add configuration for tables
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
