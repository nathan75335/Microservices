using AutoMapper;
using BookingService.BusinessLogic.DTO_s;
using BookingService.BusinessLogic.RabbitMq;
using BookingService.DataAccess.Repositories;

namespace BookingService.BusinessLogic.Jobs
{
    /// <summary>
    /// Configuration of the recurrent job
    /// </summary>
    public class SenderNotificationJob
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageSenderRabbitMq _messageSender;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="SenderNotificationJob"/>
        /// </summary>
        /// <param name="orderRepository">The order repository</param>
        /// <param name="publishEndpoint">The publisher of masstransit</param>
        /// <param name="mapper">The mapper</param>
        public SenderNotificationJob(IOrderRepository orderRepository, IMapper mapper, IMessageSenderRabbitMq messageSender)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _messageSender = messageSender;
        }

        /// <summary>
        /// Function to send notification to rabbit mq
        /// </summary>
        public void SendNotificationToReturnBook()
        {
            var list = _orderRepository.GetOrders();
            
            foreach(var order in list)
            {
                if(order.ReturnBookDate.Day - DateTimeOffset.Now.Day == 1)
                {
                    _messageSender.SendMessage<OrderDto>(_mapper.Map<OrderDto>(order));
                }
            }
        }
    }
}
