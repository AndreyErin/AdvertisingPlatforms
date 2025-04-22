using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingPlatformsService : IAdvertisingPlatformsService
    {
        private FileRepository<AdvertisingPlatform> _advertisingPlatformsRepository;
        private ILocationsService _locationsService;

        public AdvertisingPlatformsService(FileRepository<AdvertisingPlatform> advertisingsRepository, 
                                           ILocationsService locationsSevice)
        {
            _locationsService = locationsSevice;
            _advertisingPlatformsRepository = advertisingsRepository;
        }

        public List<string> GetAdvertisingPlatformsForLocation(string locationName)
        {
            List<string> result = new();

            var location = _locationsService.GetByName(locationName);

            if (location != null && location.AdvertisingIPlatformds != null)
            {
                var advertisingNames = _advertisingPlatformsRepository.GetByIdFromRepository(location.AdvertisingIPlatformds)
                    .Select(x=>x.Name)
                    .ToList();

                result = advertisingNames;
            }

            return result;
        }

        public int ReplaceRepository(List<AdvertisingPlatform> newEntitiesList)
        {
            _advertisingPlatformsRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count();    
        }
    }
}
