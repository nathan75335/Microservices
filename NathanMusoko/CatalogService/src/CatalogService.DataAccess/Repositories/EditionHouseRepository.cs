using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogService.DataAccess.Repositories
{
    /// <summary>
    /// Implementation of the repository for crud operations on Edition table
    /// </summary>
    public class EditionHouseRepository : IEditionHouseRepository
    {
        private readonly BookContext _context;
        private readonly DbSet<EditionHouse> _editionHouses;
        private readonly ILogger<EditionHouse> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="EditionHouseRepository"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_logger"></param>
        public EditionHouseRepository(BookContext context, ILogger<EditionHouse> logger)
        {
            _context = context;
            _editionHouses = _context.Set<EditionHouse>();
            _logger = logger;
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <returns>List of <see cref="EditionHouse"/></returns>
        public Task<List<EditionHouse>> GetEditionHousesByCityAsync(string city, CancellationToken cancellationToken)
        {
            return _editionHouses
                .Where(i => i.City == city)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The id of the edition house</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<EditionHouse?> GetEditionHouseAsync(int id, CancellationToken cancellationToken)
        {
            return _editionHouses
                .AsNoTracking()
                .FirstOrDefaultAsync(edition => edition.Id == id, cancellationToken);
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <param name="house">The Edition That we want to add</param>
        public void Add(EditionHouse house)
        {
            _editionHouses.Add(house);

            _logger.LogInformation($"Added the edition House {house.Name} to The database");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="house">The Edition House that we want to update</param>
        public void Update(EditionHouse house)
        {
            _editionHouses.Update(house);

            _logger.LogInformation($"Updated the edition House {house.Name}");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="house">The edition house that we want to delete</param>
        public void Delete(EditionHouse house)
        {
            _editionHouses.Remove(house);

            _logger.LogInformation($"Deleted the edition House {house.Name}");
        }
    }
}
