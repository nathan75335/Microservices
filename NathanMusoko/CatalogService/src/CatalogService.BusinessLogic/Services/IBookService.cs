using CatalogService.BusinessLogic.DTOs;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The book service to manage books in the database
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Function to add a book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>The created book</returns>
        Task<BookDto> AddAsync(BookDto book, CancellationToken cancellationToken);

        /// <summary>
        /// Function To get a book
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>A Task that contains <see cref="BookDto"/></returns>
        Task<BookDto> GetBookAsync(BookDto book, CancellationToken cancellationToken);

        /// <summary>
        /// Function
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        Task<IEnumerable<BookDto>> GetBooksByGenreAsync(string genre, CancellationToken cancellationToken);

        /// <summary>
        /// Function to delete a book from the database
        /// </summary>
        /// <param name="book">The book that we want to delete</param>
        /// <returns>A Task That contains <see cref="BookDto"/></returns>
        Task<BookDto> RemoveAsync(BookDto book, CancellationToken cancellationToken);

        /// <summary>
        /// Function to update a book from the database
        /// </summary>
        /// <param name="book">The book to update</param>
        /// <returns>A task that contains <see cref="BookDto"/></returns>
        Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken);
    }
}
