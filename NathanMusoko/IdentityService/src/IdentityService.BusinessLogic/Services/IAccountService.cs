using IdentityService.BusinessLogic.DTOs;

namespace IdentityService.BusinessLogic.Services
{
    /// <summary>
    /// The account service to manage the accounts of users
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Function to add a new user to the database
        /// </summary>
        /// <param name="user">The use That we want to add</param>
        /// <param name="password">The password of the user</param>
        /// <returns>A <see cref="Task"/></returns>
        Task<bool> CreateUserAsync(UserDto user, string password);

        /// <summary>
        /// Function to delete a user from the database
        /// </summary>
        /// <param name="user">The user that we want to delete</param>
        /// <returns>A <see cref="Task"/> that contains a <see cref="UserDto"/> <T</returns>
        Task<UserDto> DeleteUserAsync(UserDto user);

        /// <summary>
        /// Function to reset the password of the user
        /// </summary>
        /// <param name="user">The user for whom we want to reset the password</param>
        /// <param name="password">The password </param>
        /// <param name="newPassword"></param>
        /// <returns>A <see cref="Task"/> that contains true if the password has been
        /// reseted and false in the other case</returns>
        Task<bool> ResetPasswordAsync(UserDto user, string password, string newPassword);

        /// <summary>
        /// Function to update the password of the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="oldPassword">The old password of the user</param>
        /// <param name="newPassword">The new password of the user</param>
        /// <returns>A <see cref="Task"/> That contains true if the password has been
        /// update and false in the other case</returns>
        Task<bool> UpdatePasswordAsync(UserDto user, string oldPassword, string newPassword);

        /// <summary>
        /// Function to update the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A <see cref="Task"/> That contains the updated user 
        /// <see cref="UserDto"/></returns>
        Task<bool> UpdateUserAsync(UserDto user);

        /// <summary>
        /// Function to add the update the claims of the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A <see cref="Task"/></returns>
        Task UpdateUserClaimsAsync(UserDto user, CancellationToken cancellationToken);
    }
}
