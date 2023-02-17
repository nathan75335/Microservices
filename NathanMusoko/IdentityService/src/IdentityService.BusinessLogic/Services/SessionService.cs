using AutoMapper;
using IdentityService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.BusinessLogic.Services
{
    /// <summary>
    /// Implementatio of the session service to manage the session of the user
    /// </summary>
    public class SessionService : ISessionService
    { 
        private readonly SignInManager<User> signInManager;

        /// <summary>
        /// Initializes a new instance of <see cref="SessionService"/>
        /// </summary>
        /// <param name="signInManager">The sign in manager</param>
        public SessionService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Function to log out the app 
        /// </summary>
        /// <returns>A <see cref="Task"/></returns>
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
