using CatalogService.DataAccess.Models;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// Edition house repository to operate crud on Edition House
    /// </summary>
    public interface IEditionHouseRepository
    {
        /// <summary>
        /// Function to add an edition House
        /// </summary>
        /// <param name="house">The edition House that we want to add</param>
        /// <returns>A <see cref="Task"/></returns>
        void Add(EditionHouse house);
        
        /// <summary>
        /// Function To delete an edition house
        /// </summary>
        /// <param name="house">The edition house that we want to delete</param>
        /// <returns>A <see cref="Task"/></returns>
        void Delete(EditionHouse house);

        /// <summary>
        /// Function to get the edition houses from the database
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A List of  <see cref="EditionHouse"/></returns>
        Task<List<EditionHouse>> GetEditionHousesByCityAsync(string city, CancellationToken cancellationToken);

        /// <summary>
        /// Function to update an edition house from the database
        /// </summary>
        /// <param name="house">The edition house that we want to update</param>
        /// <returns>A <see cref="Task"/></returns>
        void Update(EditionHouse house);

        /// <summary>
        /// Function to get an edition house by id
        /// </summary>
        /// <param name="id">The id of the edition house</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A<see cref="Task"/> that contains <seealso cref="EditionHouse"/></returns>
        Task<EditionHouse?> GetEditionHouseAsync(int id, CancellationToken cancellationToken);
    }
}
