using System.Runtime.Serialization;

namespace BookingService.BusinessLogic.Exceptions
{
    /// <summary>
    /// The not found exception
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/>
        /// </summary>
        public NotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="message">The message</param>
        public NotFoundException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
