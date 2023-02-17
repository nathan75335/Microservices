using IdentityService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// The user refresh repository for crud operations for the user refresh table
    /// </summary>
    public class UserRefreshRepository : IUserRefreshRepository
    {
        private readonly IdentityContext _context;
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;
        private readonly ILogger<UserRefreshRepository> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="UserRefreshRepository"/>
        /// </summary>
        /// <param name="context">The data base Context of the application</param>
        /// <param name="logger">The logger</param>
        public UserRefreshRepository(IdentityContext context, ILogger<UserRefreshRepository> logger)
        {
            _context = context;
            _logger = logger;
            _userRefreshTokens = _context.Set<UserRefreshToken>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="token">The token that we want to add</param>
        /// <returns>A <see cref="Task"/></returns>
        public void AddUserRefreshToken(UserRefreshToken token)
        {
            var result = _userRefreshTokens.Add(token);
            
            _logger.LogInformation("Added a user refresh Token");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="refreshToken">The user refresh token to update</param>
        /// <returns>A <see cref="Task"/></returns>
        public void UpdateUserRefreshToken(UserRefreshToken refreshToken)
        {
            _userRefreshTokens.Update(refreshToken);

            _logger.LogInformation("Deleted the refresh token");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="tokenRefresh">The refrsesh token that we want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task that contains a <see cref="UserRefreshToken"/></returns>
        public Task<UserRefreshToken> GetSavedUserRefreshTokensAsync(string tokenRefresh, CancellationToken cancellationToken)
        {
            return _userRefreshTokens.Include(i => i.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RefreshToken == tokenRefresh, cancellationToken);     
        }
    }
}
