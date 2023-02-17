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
    public class EditionHousesConroller : Controller
    { 
        private readonly IEditionHouseService _service;

        /// <summary>
        /// Initializes a new instance of <see cref="EditionHousesConroller"/>
        /// </summary>
        /// <param name="service">The service</param>
        public EditionHousesConroller(IEditionHouseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Function to get all edition houses
        /// </summary>
        /// <returns> A <see cref="IActionResult"/></returns>
        [HttpGet("getall/{city}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEditionHouses(string city, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllByCityAsync(city, cancellationToken);

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
        [HttpGet("add/{edition}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddEditionHouse(EditionHouseDto edition, CancellationToken cancellationToken)
        {
            await _service.AddAsync(edition, cancellationToken);

            return Ok(edition);
        }

        /// <summary>
        /// Action to update an edition house
        /// </summary>
        /// <param name="edition"></param>
        /// <returns></returns>
        [HttpGet("updateeditionhouse/{edition}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateEditionHouse(EditionHouseDto edition,CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(edition, cancellationToken);

            return Ok(edition);
        }

        /// <summary>
        /// Action to Delete an edition house
        /// </summary>
        /// <param name="edition"></param>
        /// <returns></returns>
        [HttpGet("addeditionhouse/{edition}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteEditionHouse(EditionHouseDto edition, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(edition, cancellationToken);

            return Ok(edition);
        }
    }
}
