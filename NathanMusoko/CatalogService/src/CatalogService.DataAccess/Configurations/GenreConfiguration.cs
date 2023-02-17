using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.DataAccess.Configurations
{
    /// <summary>
    /// The configuration for the genre of the book
    /// </summary>
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
                .IsRequired(true);
            builder.Property(i => i.Descritpion)
                .IsRequired(true);
            
            builder.ToTable("Genres");
        }
    }
}
