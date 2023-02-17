using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using SenderService.Consumer.Contracts;
using SenderService.Consumer.Sender;
using RabbitMQ.Client.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SenderService.Consumer.Consumer
{
    /// <summary>
    /// The order consumer
    /// </summary>
    public class OrderConsumer : BackgroundService
    {
        private readonly ISenderMessage sender;
        private readonly ILogger<OrderConsumer> logger;

        /// <summary>
        /// Initializes a new instance of <see cref="OrderConsumer"/>
        /// </summary>
        /// <param name="sender">The sender of messages</param>
        public OrderConsumer(ISenderMessage sender, ILogger<OrderConsumer> logger)
        {
            this.sender = sender;
            this.logger = logger;
        }

        /// <summary>
        /// Function to consume message as a background service
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns>A <see cref="Task"/></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "http://rabbitmq",
                Port = 5672
            };

            try
            {
                var connection = factory.CreateConnection();

                logger.LogInformation("Started the Bus");

                using var channel = connection.CreateModel();
                channel.QueueDeclare("orders", exclusive: false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    logger.LogInformation($"Message received: {message}");

                    var order = JsonConvert.DeserializeObject<OrderDto>(message);

                    logger.LogInformation("Deserialized te consumed object ");

                    string subject = "Reminder about the book";

                    StringBuilder template = new StringBuilder();
                    template.Append("<h2>Dear, You have return the book tomorrow.</h2>");
                    template.Append("<p>Thanks For choosing us </p>");

                    sender.SendMessage(subject, "Nathankaleng@gmail.com", order.UserEmail, template.ToString());

                    logger.LogInformation("Sended the Email to the user");

                };

                channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);
                Console.ReadKey();
            }
            catch(BrokerUnreachableException ex)
            {
                logger.LogError($"An error occured while trying to connect to rabbit mq {ex.Message}");

                Console.WriteLine($"Could not connect to rabbit mq {ex.Message} ");
            }
            catch(Exception ex)
            {
                logger.LogError($"An error occured while consuming {ex.Message}");

                Console.WriteLine($"Could not consume the message {ex.Message}");
            }

            await  Task.CompletedTask;
        }
    }
}
