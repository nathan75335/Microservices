
namespace CatalogService.DataAccess.Models
{
    /// <summary>
    /// The edition house where the book has been edited
    /// </summary>
    public class EditionHouse
    {
        /// <summary>
        /// The id of the House of edition
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the House of edition
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The city where is situated the edition house
        /// </summary>
        public string City {get;set;}

        /// <summary>
        /// The street of the edition house
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The number of the house of the house of edition
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// the navigatio property for book
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
