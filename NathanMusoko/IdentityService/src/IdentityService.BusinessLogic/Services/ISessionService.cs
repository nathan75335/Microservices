using IdentityService.BusinessLogic.DTOs;

namespace IdentityService.BusinessLogic.Services
{
    /// <summary>
    /// The session service to manage sessions
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Function Logout the app
        /// </summary>
        /// <returns>A <see cref="Task"/></returns>
        Task LogoutAsync();
    }
}
