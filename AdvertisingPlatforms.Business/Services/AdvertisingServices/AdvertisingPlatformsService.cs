using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingPlatformsService : IAdvertisingPlatformsService
    {
        private Repository<AdvertisingPlatform> _advertisingPlatformsRepository;
        private ILocationsService _locationsService;

        public AdvertisingPlatformsService(Repository<AdvertisingPlatform> advertisingsRepository, 
                                           ILocationsService locationsSevice)
        {
            _locationsService = locationsSevice;
            _advertisingPlatformsRepository = advertisingsRepository;
        }

        /// <summary>
        /// Get advertisings for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns></returns>
        public List<string> GetAdvertisingPlatformsForLocation(string locationName)
        {
            List<string> result = new();

            var location = _locationsService.GetByName(locationName);

            if (location?.AdvertisingPlatformIds.Count > 0)
            {
                var advertisingNames = _advertisingPlatformsRepository.GetByIdFromRepository(location.AdvertisingPlatformIds)
                    .Select(x=>x.Name)
                    .ToList();

                result = advertisingNames;
            }

            return result;
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<AdvertisingPlatform> newEntitiesList)
        {
            _advertisingPlatformsRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count;    
        }
    }
}
