using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.DataAccess
{
    /// <summary>
    /// The identity context of the application
    /// </summary>
    public class IdentityContext : IdentityDbContext<User, Role, int, UserClaim,
         IdentityUserRole<int>,
         IdentityUserLogin<int>,
         IdentityRoleClaim<int>,
         IdentityUserToken<int>>
    {
        /// <summary>
        ///  Initializes a new instance of <see cref="IdentityContext"/>
        /// </summary>
        /// <param name="options">Options by default</param>
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
          
        }

        /// <summary>
        /// Overrding the in modelCreating of the IdentityDbContext to add our configuration
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder of the database context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
