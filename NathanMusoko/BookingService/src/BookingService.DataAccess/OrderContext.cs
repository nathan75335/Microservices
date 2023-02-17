using Microsoft.EntityFrameworkCore;

namespace BookingService.DataAccess
{
    /// <summary>
    /// thr order context of the application
    /// </summary>
    public class OrderContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OrderContext"/>
        /// </summary>
        /// <param name="options"></param>
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        /// <summary>
        /// Applying t configuration to the context
        /// </summary>
        /// <param name="builder">The builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
