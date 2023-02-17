using IdentityService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// The user claim repository for the crud operation of the user claim
    /// </summary>
    public class UserClaimRepository : IUserClaimRepository
    {
        private readonly IdentityContext _context;
        private readonly DbSet<UserClaim> _claims;
        private readonly ILogger<UserClaimRepository> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="UserClaimRepository"/>
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="logger">the logger</param>
        public UserClaimRepository(IdentityContext context, ILogger<UserClaimRepository> logger)
        {
            _context = context;
            _claims = _context.Set<UserClaim>();
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <param name="user">the user for whom we want to add the claim</param>
        /// <param name="claims">The claims of the user </param>
        public void UpdateUserClaim(List<UserClaim> claims)
        {
            _claims.UpdateRange(claims);

            _logger.LogInformation("Updating the userClaim");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The id of the user that we want to get the claims</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>List of <see cref="UserClaim"/></returns>
        public Task<List<UserClaim>> GetUserClaimsAsync(int id, CancellationToken cancellationToken)
        {  
            return _claims
               .Where(userClaim => userClaim.Id == id)
               .AsNoTracking()
               .ToListAsync(cancellationToken);
        }
    }
}
