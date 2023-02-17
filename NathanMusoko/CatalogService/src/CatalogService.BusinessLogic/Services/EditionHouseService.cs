using AutoMapper;
using CatalogService.BusinessLogic.DTOs;
using CatalogService.BusinessLogic.Exceptions;
using CatalogService.DataAccess.Models;
using CatalogService.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace CatalogService.BusinessLogic.Services
{
    /// <summary>
    /// The edition house service to manage the edition houses
    /// </summary>
    public class EditionHouseService : IEditionHouseService
    {
        private readonly ILogger<EditionHouseRepository> _logger;
        private readonly IEditionHouseRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISaveChangesRepository _saveChangesRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="EditionHouseService"/>
        /// </summary>
        /// <param name="logger">Logger to log information on the console</param>
        /// <param name="repository">Repository for EditionHouse</param>
        public EditionHouseService(ILogger<EditionHouseRepository> logger,
            IEditionHouseRepository repository, IMapper mapper,
            ISaveChangesRepository saveChangesRepository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _saveChangesRepository = saveChangesRepository;
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="house">The house that we want to add</param>
        /// <returns>A <see cref="Task"/></returns>
        public async Task AddAsync(EditionHouseDto house, CancellationToken cancellationToken)
        {
            var houseMapped = _mapper.Map<EditionHouse>(house);
            var edition = await _repository.GetEditionHouseAsync(houseMapped.Id, cancellationToken);

            if (edition != null)
            {
                _logger.LogError("Error occured while adding a edition house in the databse");

                throw new AlreadyExistException("This Edition House Already Exist");
            }

            try
            {
                _repository.Add(houseMapped);
                await _saveChangesRepository.SaveChangesAsync();
                _logger.LogInformation("Saved changes in the database");
            }
            catch(Exception ex)
            {
                _logger.LogError("The Edition house exists");

                throw new ArgumentException("Could not save the changes to the database",ex.Message);   
            }
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <param name="house">The house that we want to Delete</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        public async Task DeleteAsync(EditionHouseDto house, CancellationToken cancellationToken)
        {
            var houseMapped = _mapper.Map<EditionHouse>(house);
            var edition = await _repository.GetEditionHouseAsync(houseMapped.Id, cancellationToken);

            if (edition == null)
            {
                _logger.LogError("The Edition was not Updated because it does not exist");

                throw new NotFoundException("The edition house was not found");
            }

            try
            {
                _repository.Delete(edition);
                await _saveChangesRepository.SaveChangesAsync();
                _logger.LogInformation("Saved changes in the database");

            }catch(Exception ex)
            {
                _logger.LogError($"could not delete the edition house {houseMapped.Name}");

                throw new ArgumentException("An error occured while deleting the house edition", ex.Message);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="house">The edition house that we want to update</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">The edition house was not found</exception>
        public async Task UpdateAsync(EditionHouseDto house, CancellationToken cancellationToken)
        {
            var houseMapped = _mapper.Map<EditionHouse>(house);
            var edition = await _repository.GetEditionHouseAsync(houseMapped.Id, cancellationToken);

            if (edition == null)
            {
                _logger.LogError("The Edition was not Updated because it does not exist");

                throw new NotFoundException("The edition house was not found");
            }

            try
            {
                _repository.Update(houseMapped);
                await _saveChangesRepository.SaveChangesAsync();
                _logger.LogInformation("Saved the changes to the database");

            }catch(Exception ex)
            {
                _logger.LogError($"Error occured while updating the edition house {houseMapped.Name}");

                throw new ArgumentException("could not update the edition house to the database",ex);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>a list of edition house</returns>
        /// <exception cref="NotFoundException">The editions houses were not found</exception>
        public async Task<List<EditionHouse>> GetAllEditionHousesByCityAsync(string city, CancellationToken cancellationToken)
        {
            var list = await _repository.GetEditionHousesByCityAsync(city, cancellationToken);

            if (list == null)
            {
                _logger.LogError("The edition Houses does not exist");
                
                throw new NotFoundException("The editions houses were not found");
            }

            return list;
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <param name="house">The edition house that we want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<EditionHouseDto> GetEditionHouseAsync(EditionHouseDto house,CancellationToken cancellationToken)
        {
            var houseMapped = _mapper.Map<EditionHouse>(house);
            var edition = await _repository.GetEditionHouseAsync(houseMapped.Id, cancellationToken);

            if (edition == null)
            {
                _logger.LogError("The Edition was not Found because it does not exist");

                throw new NotFoundException("The edition house was not found");
            }

            return house;
        }
    }
}
