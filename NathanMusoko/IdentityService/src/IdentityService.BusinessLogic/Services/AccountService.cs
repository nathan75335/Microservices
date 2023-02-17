using AutoMapper;
using IdentityService.BusinessLogic.DTOs;
using IdentityService.BusinessLogic.Exceptions;
using IdentityService.DataAccess.Models;
using IdentityService.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IdentityService.BusinessLogic.Services
{
    /// <summary>
    /// The class that implements the account service
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountService> _logger;
        private readonly IUserClaimRepository _repository;
        private readonly ISaveChangesRepository _saveChangesRepository;

        /// <summary>
        ///  Initializes a new instance of <see cref="AccountService"/>
        /// </summary>
        /// <param name="userManager">The user manager from identity</param>
        /// <param name="mapper">The mapper to map object</param>
        /// <param name="logger">The logger to log information</param>
        public AccountService(UserManager<User> userManager,
            IMapper mapper,
            ILogger<AccountService> logger,
            IUserClaimRepository repository,
            ISaveChangesRepository saveChangesRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _saveChangesRepository = saveChangesRepository;
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <param name="user">The user that we want to add</param>
        /// <param name="password">The use password</param>
        /// <exception cref="AlreadyExistException">When the user already exists</exception>
        /// <returns>A <see cref="Task"/></returns>
        public async Task<bool> CreateUserAsync(UserDto user, string password)
        {
            var userMapped = _mapper.Map<User>(user);

            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(user.Email);

                if (userLooked != null)
                {
                    _logger.LogError("Error occured while creating user");

                    throw new AlreadyExistException("This user already exists");
                }

                userMapped.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(userMapped, password);
                var role = new Role(RoleTypes.RolesTypes[0]);
                await _userManager.AddToRoleAsync(userMapped, role.Name);

                return result.Succeeded;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="user">The updated user</param>
        /// <exception cref="NotFoundException">When the user is not found</exception>
        /// <returns>A <see cref="Task"/></returns>
        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var userMapped = _mapper.Map<User>(user);

            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(userMapped.Email);

                if (userLooked == null)
                {
                    _logger.LogError("Error occured while processing the reques");

                    throw new NotFoundException("User not found");
                }

                userLooked.FirstName = userMapped.FirstName;
                userLooked.LastName = userMapped.LastName;
                userLooked.HouseNumber = userMapped.HouseNumber;
                userLooked.PhoneNumber = userMapped.PhoneNumber;
                userLooked.City = userMapped.City;
                userLooked.DateOfBirth = userMapped.DateOfBirth;

                var result = await _userManager.UpdateAsync(userLooked);

                return result.Succeeded;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="user">The user that we want to delete</param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns>True if the user has been deleted or false in the other case</returns>
        public async Task<UserDto> DeleteUserAsync(UserDto user)
        {
            var userMapped = _mapper.Map<User>(user);

            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(userMapped.Email);

                if (userLooked == null)
                {
                    _logger.LogError("Error occured while processing the delete request");

                    throw new NotFoundException("The user was not found");
                }

                var result = await _userManager.DeleteAsync(userLooked);

                return user;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="user">The user for whom we want to update the password</param>
        /// <param name="oldPassword">The old password of the user</param>
        /// <param name="newPassword">the new password of the user</param>
        /// <exception cref="NotFoundException">When The user is not found</exception>
        /// <returns>The state of the request</returns>
        public async Task<bool> UpdatePasswordAsync(UserDto user,
            string oldPassword,
            string newPassword)
        {
            var userMapped = _mapper.Map<User>(user);

            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(user.Email);
                var isValid = await _userManager.CheckPasswordAsync(userMapped, oldPassword);

                if (userLooked == null || isValid == false)
                {
                    _logger.LogError("The user was not found or the password was not correct while updating");

                    throw new NotFoundException("The user was not found or the password was not correct");
                }

                var result = await _userManager.ChangePasswordAsync(userLooked, oldPassword, newPassword);

                return result.Succeeded;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="user">The user for whom we want to reset the password</param>
        /// <param name="token">The token that will be reset</param>
        /// <param name="newPassword">The new user's password</param>
        /// <exception cref="NotFoundException">When the user is not found</exception>
        /// <returns>A <see cref="Task"/> that contatins the state of the request (true if the password
        /// has been reseted and false in the other case)</returns>
        public async Task<bool> ResetPasswordAsync(UserDto user,
            string password,
            string newPassword)
        {
            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(user.Email);

                if (userLooked == null)
                {
                    _logger.LogError("Error occured while reseting password");

                    throw new NotFoundException("The user was not found");
                }

                var result = await _userManager.ChangePasswordAsync(userLooked, password, newPassword);

                return result.Succeeded;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="user">The user that we want to update the claims</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A Task</returns>
        /// <exception cref="NotFoundException">When The user is not found</exception>
        /// <returns>A <see cref="Task"/></returns>
        public async Task UpdateUserClaimsAsync(UserDto user, CancellationToken cancellationToken)
        {
            using (_userManager)
            {
                var userLooked = await _userManager.FindByEmailAsync(user.Email);

                if (userLooked == null)
                {
                    _logger.LogError("Error occured while processing the update user claims request");

                    throw new NotFoundException("The user was not found");
                }

                var claims = await _repository.GetUserClaimsAsync(userLooked.Id, cancellationToken);

                if (claims == null)
                {
                    _logger.LogError("Error occured while processing the update user claims request");

                    throw new NotFoundException("The claims are null here");
                }

                _repository.UpdateUserClaim(claims);

                await _saveChangesRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
