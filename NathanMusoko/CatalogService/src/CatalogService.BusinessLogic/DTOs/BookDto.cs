namespace CatalogService.BusinessLogic.DTOs
{
    /// <summary>
    /// The data transfert object for book
    /// </summary>
    public class BookDto
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
        /// The id of the edition house
        /// </summary>
        public int EditionHouseId { get; set; }

        /// <summary>
        /// The edition house 
        /// </summary>
        public EditionHouseDto EditionHouse { get; set; }

        /// <summary>
        /// The year of edition
        /// </summary>
        public int EditionYear { get; set; }

        /// <summary>
        /// The price of the book
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property for genres
        /// </summary>
        public List<GenreDto> Genres { get; set; }

        public DateTimeOffset CreationDate { get; set; }
    }
}
