using AutoMapper;
using CatalogService.Api.Request;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogService.Api.Controllers
{
    /// <summary>
    /// The contoller for books
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="BooksController"/>
        /// </summary>
        /// <param name="service">The Book service</param>
        /// <param name="mapper">The mapper</param>
        public BooksController(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Function To create a new Book
        /// </summary>
        /// <param name="bookRequest">The book that we want to create</param>
        /// <param name="token">The token cancellation from the http request</param>
        /// <returns>OK if the book has been created or badrequest if not</returns>
        [HttpPost("create/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromBody] BookRequestCreate bookRequest, CancellationToken token)
        {       
            var result = await _service.AddAsync(_mapper.Map<BookDto>(bookRequest), token);

            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest("Could not create the book");
        }

        /// <summary>
        /// Function to get the book by his genre
        /// </summary>
        /// <param name="genre">The genre of the book</param>
        ///<param name="token">The cancellation token coming from the http request</param>
        /// <returns>OK if the genre exist and bad request if not</returns>
        [HttpGet("get/{genre}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string genre, CancellationToken token)
        {
            var bookList = await _service.GetBooksByGenreAsync(genre, token);

            if(bookList == null)
            {
                return BadRequest("There is no book");
            }

            return Ok(bookList);
        }

        /// <summary>
        /// Function to update the Book
        /// </summary>
        /// <param name="id">The id of the book</param>
        /// <param name="bookRequest">The Book that we have to delete</param>
        /// <param name="token"></param>
        /// <returns>OK if the book has been updated and bad request if the book has not been updated</returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookRequestUpdate bookRequest, CancellationToken token)
        {
            var book = _mapper.Map<BookDto>(bookRequest);
            book.Id = id;

            var result = await _service.UpdateAsync(book, token);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Could not update the book");
        }

        /// <summary>
        /// Functon to delete the book
        /// </summary>
        /// <param name="id">The id of the book</param>
        /// <param name="token">The token coming from the Http request</param>
        /// <returns>Ok if the book has been deleted and a bad request if the book has not been updated</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook(int id, [FromBody] BookRequestUpdate bookRequest, CancellationToken token)
        {
            var book = _mapper.Map<BookDto>(bookRequest);
            book.Id = id;

            var result = await _service.RemoveAsync(book, token);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Could not delete the book");
        }
    }
}
