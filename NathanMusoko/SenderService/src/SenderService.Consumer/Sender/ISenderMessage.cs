namespace SenderService.Consumer.Sender
{
    /// <summary>
    /// The sender of message
    /// </summary>
    public interface ISenderMessage
    {
        /// <summary>
        /// Function to send a message to the user
        /// </summary>
        /// <param name="myEmail">The email of the user</param>
        /// <param name="userEmail">The user email</param>
        /// <param name="message">The message</param>
        void SendMessage(string subject, string myEmail, string userEmail, string message);
    }
}
