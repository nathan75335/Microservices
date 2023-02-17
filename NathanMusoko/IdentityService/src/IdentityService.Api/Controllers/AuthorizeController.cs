using Microsoft.AspNetCore.Mvc;
using IdentityService.Api.Request;
using IdentityService.BusinessLogic.Services;

namespace IdentityService.Api.Controllers
{
    /// <summary>
    /// The authorize controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizationService _authorization;

        /// <summary>
        /// Initializes a new instance of <see cref="AuthorizeController"/>
        /// </summary>
        /// <param name="authorization">The authorization service</param>
        public AuthorizeController(IAuthorizationService authorization)
        {
            _authorization = authorization;
        }

        /// <summary>
        /// Function for authorizing the user to get acces to the application
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>OK if the user has been authorize and BadRequest if not</returns>
        [HttpPost("authorize/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Authorize([FromBody]UserRequestLogin user, CancellationToken token)
        {
            var tokenAccess = await _authorization.AuthorizeAsync(user.Email, user.Password, token);

            if(tokenAccess == null)
            {
                return Unauthorized("You are not authorized");
            }

            return Ok(tokenAccess);
        }

        /// <summary>
        /// Function to refresh the token of the user 
        /// return a new Token to the user
        /// </summary>
        ///  <param name="token">cancellation token from the HTTP request</param>
        /// <returns>the new token</returns>
        [HttpGet("refresh/{refreshToken}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken(string refreshToken, CancellationToken token)
        {
            var newToken = await _authorization.RefreshTokenAsync(refreshToken, token);

            if(newToken == null)
            {
                return BadRequest("The refresh token was not null");
            }

            return Ok(newToken);
        }

        /// <summary>
        /// Function to get the claim of the user
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <param name="token">cancellation token from the HTTP request</param>
        /// <returns>the claim of the </returns>
        [HttpGet("getUserClaim/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserClaim(int id, CancellationToken token)
        {
            var claims = await _authorization.GetUserClaimsAsync(id, token);

            if(claims == null)
            {
                return BadRequest("The claims were null");
            }

            return Ok(claims);
        }
    }
}
