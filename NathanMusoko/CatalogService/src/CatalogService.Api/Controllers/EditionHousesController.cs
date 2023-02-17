using AutoMapper;
using CatalogService.Api.Request;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogService.Api.Controllers
{
    /// <summary>
    /// The controller for the edition house
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EditionHousesController : Controller
    { 
        private readonly IEditionHouseService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="EditionHousesController"/>
        /// </summary>
        /// <param name="service">The service</param>
        /// <param name="mapper">The mapper</param>
        public EditionHousesController(IEditionHouseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Function to get all edition houses
        /// </summary>
        /// <returns> A <see cref="IActionResult"/></returns>
        [HttpGet("getall/{city}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEditionHousesByCity(string city, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllEditionHousesByCityAsync(city, cancellationToken);

            if(result == null)
            {
                return Ok("There is no edition house ...");
            }

            return Ok(result);
        }

        /// <summary>
        /// Action to add an edition house to the database
        /// </summary>
        /// <param name="edition">The edition</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="IActionResult"/></returns>
        [HttpPost("add/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEditionHouse([FromBody] EditionRequest edition, CancellationToken cancellationToken)
        {
            var editionMapped = _mapper.Map<EditionHouseDto>(edition);

            await _service.AddAsync(editionMapped, cancellationToken);

            return Ok(edition);
        }

        /// <summary>
        /// Action to update an edition house
        /// </summary>
        /// <param name="edition"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEditionHouse(int id, [FromBody] EditionRequest edition,CancellationToken cancellationToken)
        {
            var editionMapped = _mapper.Map<EditionHouseDto>(edition);
            editionMapped.Id = id;
        
            await _service.UpdateAsync(editionMapped, cancellationToken);

            return Ok(edition);
        }

        /// <summary>
        /// Action to Delete an edition house
        /// </summary>
        /// <param name="edition"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEditionHouse(int id, [FromBody] EditionRequest edition, CancellationToken cancellationToken)
        {
            var editionMapped = _mapper.Map<EditionHouseDto>(edition);
            editionMapped.Id = id;

            await _service.DeleteAsync(editionMapped, cancellationToken);

            return Ok(edition);
        }
    }
}
