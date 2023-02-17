using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IdentityService.DataAccess.Models;

namespace IdentityService.DataAccess.Configurations
{
    /// <summary>
    /// The configuration for the user 
    /// </summary>
    public class IdentityUserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// The function to configure the user
        /// </summary>
        /// <param name="builder">The <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(i => i.Email).IsRequired();
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.PasswordHash).IsRequired();
            builder.Property(i => i.PhoneNumber).IsRequired(false);
            builder.Property(i => i.City).IsRequired(false);
            builder.Property(i => i.PhoneNumber).IsRequired(false);
            builder.Property(i => i.City).IsRequired(false);

            builder.ToTable("Users");
        }
    }
}
