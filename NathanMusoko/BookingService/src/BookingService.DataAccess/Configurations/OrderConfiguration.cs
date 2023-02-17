using BookingService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.DataAccess.Configurations
{
    /// <summary>
    /// Configuration of the order table
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configure the order table
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.BookId)
                .IsRequired(true);
            builder.Property(x => x.UserEmail)
                .IsRequired(true);
            builder.Property(x => x.BorrowBookDate)
                .IsRequired(true);
            builder.Property(x => x.ReturnBookDate)
                .IsRequired(true);

            builder.ToTable("Orders");
        }
    }

}
