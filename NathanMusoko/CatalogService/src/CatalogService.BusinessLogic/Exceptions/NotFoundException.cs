
namespace CatalogService.BusinessLogic.Exceptions
{
    /// <summary>
    /// The Not found exception
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
        /// <param name="message">The message for the exception</param>
        public NotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="NotFoundException"/>
        /// </summary>
        /// <param name="message">The message to pass to the exception</param>
        /// <param name="innerException">The exception</param>
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
