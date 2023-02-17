using AutoMapper;
using BookingService.BusinessLogic.DTO_s;
using BookingService.BusinessLogic.Exceptions;
using BookingService.DataAccess.Models;
using BookingService.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace BookingService.BusinessLogic.Services
{
    /// <summary>
    /// Implementation of the order service
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="OrderService"/>
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="logger"></param>
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> That contains an <seealso cref="OrderDto"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<OrderDto> AddAsync(OrderDto order, CancellationToken cancellationToken)
        {
            var orderMapped = _mapper.Map<Order>(order);

            try
            {
                _orderRepository.Add(orderMapped);
                await _orderRepository.SavesChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while adding The order to the database {ex.Message}");

                throw new ArgumentException($"Could not add the order to the database  {ex.Message}");
            }

            _logger.LogInformation("Added a new order to the database");

            return order;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Task"/> that contains <seealso cref="OrderDto"/></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<OrderDto> UpdateAsync(OrderDto order, CancellationToken cancellationToken)
        {
            var orderMapped = _mapper.Map<Order>(order);
            var orderLooked = await _orderRepository.GetOrderAync(orderMapped.Id, cancellationToken);

            if (orderLooked == null)
            {
                _logger.LogError($"Error occured while updating the order {order.Id} to the database order not found");

                throw new NotFoundException("The order was not found ");
            }

            try
            {
                _orderRepository.Update(orderLooked);
                await _orderRepository.SavesChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating The order to the database {ex.Message}");

                throw new ArgumentException($"Could not update the order to the database  {ex.Message}");
            }

            _logger.LogInformation("Updated the order to the database");

            return order;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var orderLooked = await _orderRepository.GetOrderAync(id, cancellationToken);

            if (orderLooked == null)
            {
                _logger.LogError($"Error occured while deleting the order {id} to the database order not found");

                throw new NotFoundException("The order was not found ");
            }

            try
            {
                _orderRepository.Delete(orderLooked);
                await _orderRepository.SavesChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating The order to the database {ex.Message}");

                throw new ArgumentException($"Could not update the order to the database  {ex.Message}");
            }

            _logger.LogInformation("Updated the order to the database");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Task"/> that contains <seealso cref="OrderDto"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<List<OrderDto>> GetOrdersByUserAsync(string email, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrderByUserAsync(email, cancellationToken);

            if (orders == null)
            {
                _logger.LogError($"Error occured while looking the order {email} to the database order not found");

                throw new NotFoundException("The orders was not found ");
            }

            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
