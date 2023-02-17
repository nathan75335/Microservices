using Microsoft.Extensions.Logging;

namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// Implementation of the save changes repository
    /// </summary>
    public class SaveChangesRepository : ISaveChangesRepository
    {
        private readonly IdentityContext _context;
        private readonly ILogger<SaveChangesRepository> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="SaveChangesRepository"/>
        /// </summary>
        /// <param name="context">The identity context</param>
        /// <param name="logger">The logger</param>
        public SaveChangesRepository(IdentityContext context, ILogger<SaveChangesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="token">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        public Task SaveChangesAsync(CancellationToken token)
        {
            _logger.LogInformation("Saving the changes to the database");

            return _context.SaveChangesAsync(token);
        }
    }
}
