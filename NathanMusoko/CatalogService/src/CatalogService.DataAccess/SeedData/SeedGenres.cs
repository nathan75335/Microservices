using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess.SeedData
{
    /// <summary>
    /// The seed data class for genres
    /// </summary>
    public class SeedGenres
    {
        private readonly BookContext _context;
        private readonly DbSet<Genre> _genres;
       
        private readonly List<Genre> genresList = new()
        {
            new Genre
            {
                Name = "Romance",
                Descritpion = "Talks about love and passion"
            },
            new Genre
            {
                Name = "Drama",
                Descritpion = "Talks about Drama"
            },
            new Genre
            {
                Name = "Fantasy",
                Descritpion = "Talks about fantasy"
            },
            new Genre
            {
                Name = "Science Fiction",
                Descritpion = "Talks about science Fiction"
            },
            new Genre
            {
                Name = "Adventure",
                Descritpion = "Talks about adventure"
            },
            new Genre
            {
                Name = "Mystery",
                Descritpion = "Talks about Mystery"
            },
            new Genre
            {
                Name = "Thriller",
                Descritpion = "Talks about Thriller"
            },
            new Genre
            {
                Name = "Historical",
                Descritpion = "Talks about History"
            }
        };

        /// <summary>
        /// Initializes a new instance of <see cref="SeedGenres"/>
        /// </summary>
        /// <param name="context">The context of the application</param>
        public SeedGenres(BookContext context)
        {
            _context = context;
            _genres = _context.Set<Genre>();
        }

        /// <summary>
        /// Function add seed data of genres
        /// </summary>
        public async Task SeedDataAsync(CancellationToken cancellationToken)
        {
            if (!_genres.Any())
            {
                await _genres.AddRangeAsync(genresList, cancellationToken);
            }

            await _context.SaveChangesAsync();
        }
    }
}
