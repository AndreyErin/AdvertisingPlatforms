using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingsInLocationService : IAdvertisingsInLocationService
    {
        private readonly IAdvertisingPlatformsService _advertisingPlatformsService;
        private readonly ILocationsService _locationsService;
        private static List<AdvertisingsInLocation> _thisRepo = new List<AdvertisingsInLocation>()
        {
            new AdvertisingsInLocation(1, 1, [1]),
            new AdvertisingsInLocation(2, 2, [1, 2, 3]),
            new AdvertisingsInLocation(3, 3, [1, 2, 3]),
            new AdvertisingsInLocation(4, 4, [1, 4]),
            new AdvertisingsInLocation(5, 5, [1, 4]),
            new AdvertisingsInLocation(6, 6, [1, 4]),
            new AdvertisingsInLocation(7, 7, [1, 3]),
        };
        public AdvertisingsInLocationService(IAdvertisingPlatformsService advertisingPlatformsService, ILocationsService locationsService)
        {
            _advertisingPlatformsService = advertisingPlatformsService;
            _locationsService = locationsService;
        }

        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        /// <exception cref="BusinessException"></exception>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName)
        {
            try
            {
                var locationId = _locationsService.GetByName(locationName)?.Id;

                var advertisingsInLocation = _thisRepo.Find(x => x.LocationId == locationId);

                return advertisingsInLocation?.AdvertisingIds
                    .Select(x=> _advertisingPlatformsService.GetById(x).Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new BusinessException(
                    ErrorConstants.ServiceGetData,
                    ex);
            }
        }

        public int ReplaceRepository(IReadOnlyList<AdvertisingsInLocation> newEntitiesList)
        {
            _thisRepo = (List<AdvertisingsInLocation>)newEntitiesList;
            return _thisRepo.Count;
        }
    }
}
