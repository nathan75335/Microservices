namespace SenderService.Consumer.Contracts
{
    /// <summary>
    /// The order request to consume the message
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// The id of the user
        /// </summary>
        public int UserId { get; set; }

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
