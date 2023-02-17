using IdentityService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.DataAccess.Configurations
{
    /// <summary>
    /// The configuration fof the role of the user
    /// </summary>
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Function to configure the role of the user 
        /// </summary>
        /// <param name="builder">Te <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.Name).IsRequired();
            builder.ToTable("Roles");
        }
    }
}
