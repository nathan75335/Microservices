using AutoMapper;
using BookingService.Api.Requests;
using BookingService.BusinessLogic.DTO_s;
using BookingService.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api
{
    /// <summary>
    /// The controller of the orders
    /// </summary>
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="OrdersController"/>
        /// </summary>
        /// <param name="orderService">The order service</param>
        /// <param name="logger">The logger</param>
        /// <param name="mapper">The mapper</param>
        public OrdersController(IOrderService orderService,
            ILogger<OrdersController> logger,
            IMapper mapper)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Function to create an order in the database
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="IActionResult"/></returns>
        [HttpPost("create/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest order, CancellationToken cancellationToken)
        {
            var orderMapped = _mapper.Map<OrderDto>(order);

            var result = await _orderService.AddAsync(orderMapped, cancellationToken);

            _logger.LogInformation("Added successfully an order to the database");

            return Ok(order);
        }

        /// <summary>
        /// Function to update an order in the database
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="IActionResult"/></returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequest order, CancellationToken cancellationToken)
        {
            var orderMapped = _mapper.Map<OrderDto>(order);
            orderMapped.Id = id;

            var result = await _orderService.UpdateAsync(orderMapped, cancellationToken);

            _logger.LogInformation("Updated successfully an order to the database");

            return Ok(result);
        }

        /// <summary>
        /// Function to delete an order in the database
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="IActionResult"/></returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            await _orderService.DeleteAsync(id, cancellationToken);

            _logger.LogInformation("Deleted successfully an order to the database");

            return Ok(id);
        }

        /// <summary>
        /// Function to get the orders of the user
        /// </summary>
        /// <param name="id">The id of the order</param>
        /// <param name="order">The order</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/> that contains <seealso cref="IActionResult"/></returns>
        [HttpGet("getordersbyuser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrdersByUser(string userEmail, CancellationToken cancellationToken)
        {
            var list = await _orderService.GetOrdersByUserAsync(userEmail, cancellationToken);

            return Ok(list);
        }
    }
}
