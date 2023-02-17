namespace IdentityService.Api.Request
{
    /// <summary>
    /// The user for the login request
    /// </summary>
    public class UserRequestLogin
    {
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
}
