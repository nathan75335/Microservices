
namespace CatalogService.DataAccess.Models
{
    /// <summary>
    /// The book for the libray
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The id of the book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The author of the book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The edition House id of the book
        /// </summary>
        public int EditionHouseId { get; set; }

        /// <summary>
        /// The edition house of the book
        /// </summary>
        public EditionHouse EditionHouse { get; set; }

        /// <summary>
        /// The year of edition
        /// </summary>
        public int EditionYear { get; set; }

        /// <summary>
        /// The price of the book
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The genre of the book
        /// </summary>
        public List<Genre> Genres { get; set; }

        public DateTimeOffset CreationDate { get; set; }
    }
}
