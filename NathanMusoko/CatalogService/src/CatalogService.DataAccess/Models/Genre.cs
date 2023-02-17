
namespace CatalogService.DataAccess.Models
{
    /// <summary>
    /// The genre of the books
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// The id of the genre
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the genres
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Description of the genre
        /// </summary>
        public string Descritpion { get; set; }

        /// <summary>
        /// The navigation property for the book
        /// </summary>
        public List<Book> Books { get; set; }    
    }
}
