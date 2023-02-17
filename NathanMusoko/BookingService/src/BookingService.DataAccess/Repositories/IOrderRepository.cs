using BookingService.DataAccess.Models;

namespace BookingService.DataAccess.Repositories
{
    /// <summary>
    /// The Repository for the order model
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Function to add an order to the database
        /// </summary>
        /// <param name="order"></param>
        void Add(Order order);

        /// <summary>
        /// Function to delete an order from the database
        /// </summary>
        /// <param name="order"></param>
        void Delete(Order order);

        /// <summary>
        /// Function to get an order by id 
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<Order?> GetOrderAync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Function to get orders by the id of the user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<List<Order>> GetOrderByUserAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Function to get all the order from the database
        /// </summary>
        /// <returns>A List of <see cref="Order"/></returns>
        List<Order> GetOrders();

        /// <summary>
        /// Function to save the changes to the database
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A<see cref="Task"/></returns>
        Task SavesChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Function to update an order 
        /// </summary>s
        /// <param name="order">The order</param>
        void Update(Order order);
    }
}
