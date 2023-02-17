namespace BookingService.BusinessLogic.RabbitMq
{
    /// <summary>
    /// The publisher interface for rabbit mq
    /// </summary>
    public interface IMessageSenderRabbitMq
    {
        /// <summary>
        /// Function to send a message to rabbit mq
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        void SendMessage<T>(T message);
    }
}
