namespace CatalogService.Api.Request
{
    /// <summary>
    /// The request for the edition house
    /// </summary>
    public class EditionRequest
    {
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
