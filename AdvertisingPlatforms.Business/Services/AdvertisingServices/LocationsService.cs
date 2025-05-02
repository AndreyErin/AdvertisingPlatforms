using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service of locations.
    /// </summary>
    public class LocationsService : ILocationsService
    {
        private Repository<Location> _locationRepository;

        public LocationsService(Repository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        /// <summary>
        /// Get location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns></returns>
        public Location? GetByName(string name)
        {
            return _locationRepository.GetByNameFromRepository(name);
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entieies.</returns>
        public int ReplaceRepository(IReadOnlyList<Location> newEntitiesList)
        {
            _locationRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count;
        }
    }
}
