namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// Implementation of the save changes repository
    /// </summary>
    public class SaveChangesRepository : ISaveChangesRepository
    {
        private readonly BookContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="SaveChangesRepository"/>
        /// </summary>
        /// <param name="context">The context</param>
        public SaveChangesRepository(BookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>A <see cref="Task"/></returns>
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
