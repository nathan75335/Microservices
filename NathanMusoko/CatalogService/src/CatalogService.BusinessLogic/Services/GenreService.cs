using AutoMapper;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.BusinessLogic.Exceptions;
using CatalogService.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The genre service
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly ILogger<GenreService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="GenreService"/>
        /// </summary>
        /// <param name="repository">The repository</param>
        /// <param name="logger">The logger</param>
        public GenreService(IGenreRepository repository, ILogger<GenreService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>A List of <see cref="GenreDto"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<List<GenreDto>> GetGenresAsync()
        {
            var list = await _repository.GetGenresAsync();

            if (list == null)
            {
                _logger.LogError("An error occured the genre were not found");

                throw new NotFoundException("THe genres were not found");
            }

            return _mapper.Map<List<GenreDto>>(list);
        }
    }
}
