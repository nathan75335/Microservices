
namespace CatalogService.BusinessLogic.DTOs
{
    /// <summary>
    /// The data transfert object for genre
    /// </summary>
    public class GenreDto
    {
        /// <summary>
        /// The id of the genre
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the genre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the genre
        /// </summary>
        public string Description { get; set; }
    }
}
