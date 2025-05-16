using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service of locations.
    /// </summary>
    public class LocationsService : ILocationsService
    {
        private readonly Repository<Location> _locationRepository;

        public LocationsService(Repository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        /// <summary>
        /// Get location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns>Location.</returns>
        /// <exception cref="BusinessException"></exception>
        public Location? GetByName(string name)
        {
            try
            {
                return _locationRepository.GetByNameFromRepository(name);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorConstants.ServiceGetData, ex);
            }
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        /// <exception cref="BusinessException"></exception>
        public int ReplaceRepository(IReadOnlyList<Location> newEntitiesList)
        {
            try
            {
                _locationRepository.ReplaceRepository(newEntitiesList);

                return newEntitiesList.Count;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorConstants.ServiceReplaceRepository, ex);
            }
        }
    }
}
