using AutoMapper;
using IdentityService.Api.Request;
using IdentityService.BusinessLogic.DTOs;
using IdentityService.BusinessLogic.Services;
using IdentityService.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityService.Api.Controllers
{
    /// <summary>
    /// The account controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account;
        private readonly ISessionService _session;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="AccountController"/>
        /// </summary>
        /// <param name="account">The account service</param>
        /// <param name="session">The session service</param>
        /// <param name="mapper">The mapper</param>
        public AccountController(IAccountService account,
            ISessionService session,
            IMapper mapper)
        {
            _account = account;
            _session = session;
            _mapper = mapper;
        }

        /// <summary>
        /// Function To create a New User 
        /// </summary>
        /// <param name="user">The user that we want to create</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>Returns type (IActionResult) OK if the user has successfully
        /// been created or badRequest in the other condition</returns>
        [HttpPost("createuser/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestCreate user, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);
            var result = await _account.CreateUserAsync(userMapped, user.Password);

            if(result == false)
            {
                return BadRequest("The user was not created");
            }

            return Ok(user);
        }

        /// <summary>
        /// Function to logout the user 
        /// </summary>
        /// <param name="email">The email of user that we want to Logout</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>IActionResult(Ok) if the user is loggedout or 
        /// BadRequest if he is not logged out<returns>
        [HttpGet("logout/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout(CancellationToken token)
        {
            await _session.LogoutAsync();

            return Ok("Successfully...");
        }

        /// <summary>
        /// Function to Update the user 
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="email">The email of the user</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>OK the user has been updated and BadRequest if has not been updated</returns>
        [HttpPut("update/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestUpdate user, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);
            var userwaited = await _account.UpdateUserAsync(userMapped);

            if (userwaited == false)
            {
                return BadRequest("The user was not updated");
            }

            return Ok(user);
        }

        /// <summary>
        /// Function to Delete the user 
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>OK if the user has been deleted and BadRequest if he has not been
        /// Deleted</returns>
        [HttpDelete("delete/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(UserRequestUpdate user, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);

            var userwaited = await _account.DeleteUserAsync(userMapped);

            if (userwaited == null)
            {
                return BadRequest("The user was not deleted");
            }

            return Ok(user);
        }

        /// <summary>
        /// Function the Update the claims of the user 
        /// </summary>
        /// <param name="id">The id of the user </param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>OK if the claims has been updated and badRequest in the other case</returns>
        [HttpPut("updateClaim/{id}/{claims}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateClaims(int id, [FromBody] UserRequestUpdate user, [FromRoute] List<Claim> claims, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);
            userMapped.Id = id;
            var userClaims = _mapper.Map<List<UserClaim>>(claims);
            userMapped.Claims = userClaims;

            await _account.UpdateUserClaimsAsync(userMapped, token);

            return Ok(user);
        }

        /// <summary>
        /// Function to update the password of the user 
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="newPassword">The new password of the user</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>OK if the user has been updated or BadRequest if the user 
        /// has not been updated</returns>
        [HttpPut("updatePassword/{newPassword}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePassword([FromBody] UserRequestUpdate user, string newPassword, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);
            var result = await _account.UpdatePasswordAsync(userMapped, user.Password, newPassword);

            if (result == false)
            {
                return BadRequest("The password of the user was not updated");
            }

            return Ok(user);
        }

        /// <summary>
        /// Functon to reset the password of the user 
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="token">Cancellation token from the HTTP request</param>
        /// <returns>Ok if the password has been updated and badrequest in
        /// the other case</returns>
        [HttpPut("reset/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword([FromBody] UserRequestUpdate user, string newPassword, CancellationToken token)
        {
            var userMapped = _mapper.Map<UserDto>(user);
            var result = await _account.ResetPasswordAsync(userMapped, user.Password, newPassword);
            
            if (result == false)
            {
                return BadRequest("The password of the user was not updated");
            }

            user.Password = newPassword;

            return Ok(user);
        }
    }
}
