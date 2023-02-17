using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// The implementation of the repository for genres
    /// </summary>
    public class GenreRepository : IGenreRepository
    {
        private readonly BookContext _bookContext;
        private readonly DbSet<Genre> _genres;

        /// <summary>
        /// Initializes a new insrance of <see cref="GenreRepository"/>
        /// </summary>
        /// <param name="bookContext"></param>
        public GenreRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
            _genres = _bookContext.Set<Genre>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>A List of <see cref="Genre"/></returns>
        public Task<List<Genre>> GetGenresAsync()
        {
            return _genres.ToListAsync();
        }
    }
}
