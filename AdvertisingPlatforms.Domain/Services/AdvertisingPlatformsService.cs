using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingPlatformsService : IAdvertisingPlatformsService
    {
        private FileRepository<Location> _locationsRepository;
        private FileRepository<AdvertisingPlatform> _advertisingPlatformsRepository;

        public AdvertisingPlatformsService(FileRepository<Location> locationsRepository, FileRepository<AdvertisingPlatform> advertisingsRepository)
        {
            _locationsRepository = locationsRepository;
            _advertisingPlatformsRepository = advertisingsRepository;
        }

        public List<string> GetAdvertisingPlatformsForLocation(string locationName)
        {
            List<string> result = new();

            var location = _locationsRepository.GetByNameFromRepository(locationName);

            if (location != null && location.AdvertisingIPlatformds != null)
            {
                //TODO refactoring
                foreach (var advertisingPlatformId in location.AdvertisingIPlatformds)
                {
                    var advertising = _advertisingPlatformsRepository.GetByIdFromRepository(advertisingPlatformId);

                    if (advertising != null)
                    {
                        result.Add(advertising.Name);
                    }
                }
            }

            return result;
        }

        public int ReplaceAllRepositoryData(DataFromFile dataFromFile)
        {
            _advertisingPlatformsRepository.OwerwriteRepository(dataFromFile.AdvertisingPlatforms);

            _locationsRepository.OwerwriteRepository(dataFromFile.Locations);

            return dataFromFile.Locations.Count();    
        }
    }
}
