using Microsoft.AspNetCore.Identity;

namespace IdentityService.DataAccess.Models
{
    /// <summary>
    /// The role of the user inherit from identityRolee
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        ///  Initializes an instance of <see cref="Role"/>
        /// </summary>
        /// <param name="name">The name of the role</param>
        public Role(string name) : base(name)
        {

        }

        /// <summary>
        /// Navigation property for user
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
