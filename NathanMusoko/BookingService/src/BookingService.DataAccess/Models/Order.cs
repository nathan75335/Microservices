namespace BookingService.DataAccess.Models
{
    /// <summary>
    /// Model for the order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The id of the order
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The email of the user
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
