using CatalogService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.DataAccess.Configurations
{
    /// <summary>
    /// The configuration of the Edition house 
    /// </summary>
    public class EditionHouseConfiguration : IEntityTypeConfiguration<EditionHouse>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<EditionHouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
                .IsRequired(true);
            builder.Property(i => i.City)
                .IsRequired(true);
            builder.Property(i => i.Street)
                .IsRequired(true);
            builder.Property(i => i.HouseNumber)
                .IsRequired(true);

            builder.ToTable("EditionHouses");
        }
    }
}
