using AutoMapper;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.BusinessLogic.Exceptions;
using CatalogService.DataAccess.Models;
using CatalogService.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The implementation of the book service to manage books
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;
        private readonly ISaveChangesRepository _saveChangesRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="BookService"/>
        /// </summary>
        /// <param name="repository"></param>
        public BookService(IBookRepository repository,
            IMapper mapper,
            ILogger<BookService> logger,
            ISaveChangesRepository saveChangesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _saveChangesRepository = saveChangesRepository;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="AlreadyExistException"></exception>
        /// <returns>The created book</returns>
        public async Task<BookDto> AddAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookMapped = _mapper.Map<Book>(book);
            var bookInDatabase = await _repository.GetBookAsync(bookMapped.Id, cancellationToken);

            if (bookInDatabase != null)
            {
                _logger.LogError("Error occured while adding a book");

                throw new AlreadyExistException("This book already exists");
            }

            _repository.Add(bookMapped);

            try
            {
                await _saveChangesRepository.SaveChangesAsync();

                _logger.LogInformation("Saved changes in the database");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while adding a book {ex.Message}");

                throw new ArgumentException($"Something went wrong while adding the book {ex.Message}");
            }

            return book;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book that we want to delete</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<BookDto> RemoveAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookMapped = _mapper.Map<Book>(book);
            var bookInDatabase = await _repository.GetBookAsync(bookMapped.Id, cancellationToken);

            if (bookInDatabase == null)
            {
                throw new NotFoundException("The book was not found");
            }

            try 
            {
                _repository.Delete(bookMapped);
                await _saveChangesRepository.SaveChangesAsync();
                _logger.LogInformation("Saved changes in the database");
            }
            catch (Exception ex)
            { 
                throw new ArgumentException($"Something went wrong while removing the book {ex.Message}");
            }

            return book;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book to update</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookMapped = _mapper.Map<Book>(book);
            var bookInDatabase = await _repository.GetBookAsync(bookMapped.Id, cancellationToken);

            if (bookInDatabase == null)
            {
                throw new NotFoundException("The book was not found");
            }

            try
            {
                _repository.Update(bookMapped);
                await _saveChangesRepository.SaveChangesAsync();
                _logger.LogInformation("Saved changes in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while adding the book {ex.Message}");
            }

            return book;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="genre">The genre</param>
        /// <returns>A IEnumerable of  <see cref="BookDto"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<BookDto>> GetBooksByGenreAsync(string genre, CancellationToken cancellationToken)
        {
            var list = await _repository.GetBooksByGenreAsync(genre, cancellationToken);

            if (list == null)
            {
                throw new NotFoundException("The catalog of book was not found");
            }

            var listDto = _mapper.Map<List<BookDto>>(list);

            return listDto;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>A Task That contains <see cref="BookDto"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<BookDto> GetBookAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookMapped = _mapper.Map<Book>(book);
            var bookLooked = await _repository.GetBookAsync(bookMapped.Id, cancellationToken);

            if (bookLooked == null)
            {
                throw new NotFoundException("The book was not found");
            }

            return _mapper.Map<BookDto>(bookLooked);
        }
    }
}

