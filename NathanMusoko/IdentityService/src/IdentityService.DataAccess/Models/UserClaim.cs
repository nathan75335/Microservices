using Microsoft.AspNetCore.Identity;

namespace IdentityService.DataAccess.Models
{
    /// <summary>
    /// The claim  of the user
    /// </summary>
    public class UserClaim : IdentityUserClaim<int>
    {
        /// <summary>
        /// Navigation property for the user
        /// </summary>
        public virtual User User { get; set; }
    }
}
