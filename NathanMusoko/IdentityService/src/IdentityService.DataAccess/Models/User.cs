using Microsoft.AspNetCore.Identity;

namespace IdentityService.DataAccess.Models
{
    /// <summary>
    /// The user inherit from identity user
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        ///  The First Name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The city where the user lives
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The street where the user lives
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The house Number of the user
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// The birth date oof the user
        /// </summary>
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// The day of registration of the user
        /// </summary>
        public DateTimeOffset RegistrationDate { get; set; }

        /// <summary>
        /// Navigation property for the claims of the user
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; set; }

        /// <summary>
        /// The refresh Token for the user
        /// </summary>
        public virtual List<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
