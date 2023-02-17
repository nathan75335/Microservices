namespace CatalogService.BusinessLogic.Exceptions
{
    /// <summary>
    /// The already found exception
    /// </summary>
    public class AlreadyExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        public AlreadyExistException()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        /// <param name="message">The message to pass to the exception</param>
        public AlreadyExistException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public AlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
