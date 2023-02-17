using CatalogService.DataAccess.Models;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// The Book repository to operate crud operations on book
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Function to create a new book
        /// </summary>
        /// <param name="book">The book that we want to create</param>
        void Add(Book book);

        /// <summary>
        /// Function to delete a book from the database
        /// </summary>
        /// <param name="book">The book that we want to delete</param>
        /// <returns>A <see cref="Task"/></returns>
        void Delete(Book book);

        /// <summary>
        /// Function to get a book from the database
        /// </summary>
        /// <param name="book">The book that we want to get</param>
        /// <returns>A <see cref="Task"/> That contains <seealso cref="Book"/></returns>
        Task<Book> GetBookAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Function to get A book by the genre
        /// </summary>
        /// <param name="genre">The genre of the book</param>
        /// <returns>A List of <see cref="Book"/></returns>
        Task<List<Book>> GetBooksByGenreAsync(string genre, CancellationToken cancellationToken);

        /// <summary>
        /// Function to update the book
        /// </summary>
        /// <param name="book">The book that we want to update</param>
        /// <returns>A <see cref="Task"/></returns>
        void Update(Book book);
    }
}
