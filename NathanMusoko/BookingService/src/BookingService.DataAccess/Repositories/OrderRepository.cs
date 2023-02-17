using BookingService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingService.DataAccess.Repositories
{
    /// <summary>
    /// Implementation of the order repository 
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        private readonly ILogger<OrderRepository> _logger;
        private readonly DbSet<Order> _orders;

        /// <summary>
        /// Initializes a new instance of <see cref="OrderRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public OrderRepository(OrderContext context, ILogger<OrderRepository> logger, DbSet<Order> orders)
        {
            _context = context;
            _logger = logger;
            _orders = _context.Set<Order>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="order">The order</param>
        public void Add(Order order)
        {
            _orders.Add(order);

            _logger.LogInformation($"An order has been added {order.Id}");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="order">The order</param>
        public void Update(Order order)
        {
            _orders.Update(order);

            _logger.LogInformation($"An order has been Updated {order.Id}");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="order">The order</param>
        public void Delete(Order order)
        {
            _orders.Remove(order);

            _logger.LogInformation($"An order has been Updated {order.Id}");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The  id of the order</param>
        /// <param name="cancellationToken">The cancellatio token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="Order"/></returns>
        public Task<Order?> GetOrderAync(int id, CancellationToken cancellationToken)
        {
            return _orders.AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == id, cancellationToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="cancellationToken">The cancellatio token</param>
        /// <returns>A <see cref="Task"/> that contains a List of <seealso cref="Order"/></returns>
        public Task<List<Order>> GetOrderByUserAsync(string email, CancellationToken cancellationToken)
        {
            return _orders
                .Where(order => order.UserEmail == email)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>A List of <see cref="Order"/></returns>
        public List<Order> GetOrders()
        {
            return _orders.AsNoTracking().ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A<see cref="Task"/></returns>
        public Task SavesChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
