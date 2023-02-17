using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.DataAccess.Configurations
{
    /// <summary>
    /// The configuration the book entity
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Title)
                .IsRequired(true);
            builder.Property(i => i.Price)
                .IsRequired(true);
            builder.Property(i => i.Author)
                .IsRequired(true);

            builder.HasMany(i => i.Genres)
                .WithMany(x => x.Books);

            builder.HasOne(i => i.EditionHouse)
                .WithMany(x => x.Books);

            builder.ToTable("Books");
        }
    }
}
