using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// Implementation of the book repository for crud operation for books
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        private readonly DbSet<Book> _books;
        private readonly ILogger<BookRepository> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="BookRepository"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public BookRepository(BookContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _books = _context.Set<Book>();
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book"></param>
        /// <returns>A <see cref="Task"/></returns>
        public void Add(Book book)
        {
            _books.Add(book);

            _logger.LogInformation($"Adding the book {book.Title} to the database", book);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book that we want to delete</param>
        public void Delete(Book book)
        {
            _books.Remove(book);

            _logger.LogInformation($"Deleted a book in database");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book that we want to get</param>
        /// <returns>A <see cref="Book"/></returns>
        public Task<Book?> GetBookAsync(int id, CancellationToken cancellationToken)
        {
            return _books
                .Include(i => i.Genres)
                .Include(i => i.EditionHouse)
                .AsNoTracking()
                .FirstOrDefaultAsync(bookLooked => bookLooked.Id == id, cancellationToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="genre">The genre of the book</param>
        /// <returns>A list of <see cref="Book"/></returns>
        public Task<List<Book>> GetBooksByGenreAsync(string genre, CancellationToken cancellationToken)
        {
            return _books
                .Where(book => book.Genres
                .Any(genreLooked => genreLooked.Name == genre))
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book that we want to update</param>
        public void Update(Book book)
        {
            _books.Update(book);

            _logger.LogInformation($"Updated the book {book.Title}");
        }
    }
}
