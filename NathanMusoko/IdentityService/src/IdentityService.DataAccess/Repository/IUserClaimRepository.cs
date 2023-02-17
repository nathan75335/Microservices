using IdentityService.DataAccess.Models;

namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// Interface For the user claim repository 
    /// </summary>
    public interface IUserClaimRepository
    {
        /// <summary>
        /// Function to get the claims of the user
        /// </summary>
        /// <param name="id">The id if user for whom we want to get the claims</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>A list of object <see cref="UserClaim"/> </returns>
        Task<List<UserClaim>> GetUserClaimsAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Function to update the claims of the user
        /// </summary>
        /// <param name="claims">The claims that we want to update</param>
        /// <returns>Return a <see cref="Task"/></returns>
        void UpdateUserClaim(List<UserClaim> claims);
    }
}
