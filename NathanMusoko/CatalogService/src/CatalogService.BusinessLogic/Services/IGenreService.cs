using CatalogService.BusinessLogic.DTOs;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The service for the genre
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Function to get the genres from the database
        /// </summary>
        /// <returns>A List of <see cref="GenreDto"/></returns>
        Task<List<GenreDto>> GetGenresAsync();
    }
}