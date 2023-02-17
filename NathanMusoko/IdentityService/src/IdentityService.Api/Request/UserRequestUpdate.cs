namespace IdentityService.Api.Request
{
    /// <summary>
    /// The user for the update request
    /// </summary>
    public class UserRequestUpdate
    {
        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

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
        /// The Phone Number of the user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The username of the user
        /// </summary>
        public string UserName { get; set; }
    }
}
