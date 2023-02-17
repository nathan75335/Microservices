using BookingService.BusinessLogic.DTO_s;

namespace BookingService.BusinessLogic.Services
{
    /// <summary>
    /// The order servie for crud operations 
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Function to add an order to the database
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/>that contains <seealso cref="OrderDto"/></returns>
        Task<OrderDto> AddAsync(OrderDto order, CancellationToken cancellationToken);

        /// <summary>
        /// Function to delete an order from the database
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Function To get orders by the id of the user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains a list of <seealso cref="OrderDto"/></returns>
        Task<List<OrderDto>> GetOrdersByUserAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Function to upate an order
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="OrderDto"/></returns>
        Task<OrderDto> UpdateAsync(OrderDto order, CancellationToken cancellationToken);
    }
}