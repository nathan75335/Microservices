using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;

namespace SenderService.Consumer.Sender
{
    /// <summary>
    /// The email sender
    /// </summary>
    public class SenderEmail : ISenderMessage
    {
        /// <summary>
        /// Function to send email
        /// </summary>
        /// <param name="myEmail">The email</param>
        /// <param name="userEmail">The email of the user</param>
        /// <param name="message">The message</param>
        public void SendMessage(string subject, string myEmail, string userEmail, string message)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            }) ;

            Email.DefaultSender = sender;

            var email = Email
                .From(myEmail)
                .To(userEmail)
                .Subject(subject)
                .Body(message)
                .Send();
        }
    }
}
