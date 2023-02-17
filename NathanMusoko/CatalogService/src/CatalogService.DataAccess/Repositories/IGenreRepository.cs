using CatalogService.DataAccess.Models;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// Repository for genres
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Function to get the genres of the user
        /// </summary>
        /// <returns></returns>
        Task<List<Genre>> GetGenresAsync();
    }
}