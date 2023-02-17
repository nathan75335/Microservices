namespace SenderService.Consumer.Contracts
{
    /// <summary>
    /// The order  to consume the message
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// The id of the order
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The id of the user
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// The id of the book
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// The Date when the book was given
        /// </summary>
        public DateTimeOffset BorrowBookDate { get; set; }

        /// <summary>
        /// The date when the book will be return
        /// </summary>
        public DateTimeOffset ReturnBookDate { get; set; }
    }
}
