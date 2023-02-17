using IdentityService.DataAccess.Models;

namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// Interface fo the user refresh repository
    /// </summary>
    public interface IUserRefreshRepository
    {
        /// <summary>
        /// Function to add the refresh token to the database
        /// </summary>
        /// <param name="token">the user refresh token that we want to save</param>
        void AddUserRefreshToken(UserRefreshToken token);

        /// <summary>
        /// Function to Delete a refresh token from the database
        /// </summary>
        /// <param name="refreshToken">the user refresh token</param>
        void UpdateUserRefreshToken(UserRefreshToken refreshToken);

        /// <summary>
        /// Function to get a refresh token that exists in the database
        /// </summary>
        /// <param name="tokenRefresh">The user refresh token that we want to get</param>
        /// <returns>An object <see cref="UserRefreshToken"/></returns>
        Task<UserRefreshToken> GetSavedUserRefreshTokensAsync(string tokenRefresh, CancellationToken token);
    }
}
