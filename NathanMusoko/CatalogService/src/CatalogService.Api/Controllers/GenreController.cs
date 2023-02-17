using CatalogService.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    /// <summary>
    /// The controlle for genres
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        /// <summary>
        /// Initializes a new instance of <see cref="GenreController"/>
        /// </summary>
        /// <param name="service"></param>
        public GenreController(IGenreService service)
        {
            _service = service;
        }

        /// <summary>
        /// Function to get the genres
        /// </summary>
        /// <returns>A <see cref="IActionResult"/></returns>
        [HttpGet("get/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGenres()
        {
            var list = await _service.GetGenresAsync();

            return Ok(list);
        }
    }
}
