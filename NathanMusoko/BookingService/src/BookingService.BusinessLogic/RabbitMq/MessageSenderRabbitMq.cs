using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace BookingService.BusinessLogic.RabbitMq
{
    /// <summary>
    /// The publisher of rabbit mq
    /// </summary>
    public class MessageSenderRabbitMq : IMessageSenderRabbitMq
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MessageSenderRabbitMq> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="MessageSenderRabbitMq"/>
        /// </summary>
        /// <param name="configuration">The configuration</param>
        /// <param name="logger">The logger</param>
        public MessageSenderRabbitMq(IConfiguration configuration, ILogger<MessageSenderRabbitMq> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T">The type of message</typeparam>
        /// <param name="message">The message</param>
        public void SendMessage<T>(T message)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _configuration["RabbitMqSettings:Host"]
                    Port = Convert.ToInt32(_configuration["RabbitMqSettings:Port"])
                };

                var connection = factory.CreateConnection();

                using var channel = connection.CreateModel();

                channel.QueueDeclare("orders", exclusive: false);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
            }
            catch(BrokerUnreachableException ex)
            {
                _logger.LogError("Could not reach rabbbit mq");

                throw new BrokerUnreachableException(new ArgumentException($"Could not reach the rabbit mq {ex.Message}"));
            }

            _logger.LogInformation("Published an order");
        }
    }
}
