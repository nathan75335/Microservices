using IdentityService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.BusinessLogic.DTOs
{
    /// <summary>
    /// The data transfert object user
    /// </summary>
    public class UserDto : IdentityUser<int>
    {
        /// <summary>
        /// The first Name of the user 
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
        /// The house number of the user
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// the registration date of the user
        /// </summary>
        public DateTimeOffset RegistrationDate { get; set; }

        /// <summary>
        /// The claims of the user
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; set; }
    }
}
