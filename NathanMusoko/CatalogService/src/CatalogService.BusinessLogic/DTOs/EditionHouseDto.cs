
namespace CatalogService.BusinessLogic.DTOs
{
    /// <summary>
    /// The dataa transfert object for edition house 
    /// </summary>
    public class EditionHouseDto
    {
        /// <summary>
        /// The id of the edition house
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the edition house 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The city where is situated the edition house
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The street of the edition house
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The house number of the edition house
        /// </summary>
        public string HouseNumber { get; set; }
    }
}
