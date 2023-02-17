using CatalogService.BusinessLogic.DTOs;
using CatalogService.DataAccess.Models;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The edition house service to manage the editions house
    /// </summary>
    public interface IEditionHouseService
    {
        /// <summary>
        /// Function to add an edition House to the database
        /// </summary>
        /// <param name="house">The edition house</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        Task AddAsync(EditionHouseDto house, CancellationToken cancellationToken);

        /// <summary>
        /// Function to delete an edition house from the database
        /// </summary>
        /// <param name="house">The edition house</param>
        /// <param name="cancellationToken">The cancellation token</param>
        Task DeleteAsync(EditionHouseDto house, CancellationToken cancellationToken);

        /// <summary>
        /// Function to get all the edition houses
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="List{EditionHouse}"/></returns>
        Task<List<EditionHouse>> GetAllEditionHousesByCityAsync(string city, CancellationToken cancellationToken);

        /// <summary>
        /// Function to get an edition house by name
        /// </summary>
        /// <param name="house">The edition house</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains  <seealso cref="EditionHouse"/></returns>
        Task<EditionHouseDto> GetEditionHouseAsync(EditionHouseDto house, CancellationToken cancellationToken);

        /// <summary>
        /// Function to update an edition house
        /// </summary>
        /// <param name="house">The edition hous</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        Task UpdateAsync(EditionHouseDto house, CancellationToken cancellationToken);
    }
}
