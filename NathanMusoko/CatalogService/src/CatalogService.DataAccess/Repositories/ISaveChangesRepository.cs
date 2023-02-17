
namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// The save changes repository
    /// </summary>
    public interface ISaveChangesRepository
    {
        /// <summary>
        /// Function to save changes to the database
        /// </summary>
        /// <returns>A <see cref="Task"/></returns>
        Task SaveChangesAsync();
    }
}
