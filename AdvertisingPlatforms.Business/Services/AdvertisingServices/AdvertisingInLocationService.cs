using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingInLocationService : IAdvertisingInLocationService
    {
        private readonly Repository<AdvertisingInLocation> _advertisingInLocationRepository;
        private readonly IAdvertisingPlatformsService _advertisingPlatformsService;
        private readonly ILocationsService _locationsService;

        public AdvertisingInLocationService(
            Repository<AdvertisingInLocation> advertisingInLocationRepository,
            IAdvertisingPlatformsService advertisingPlatformsService, 
            ILocationsService locationsService)
        {
            _advertisingInLocationRepository = advertisingInLocationRepository;
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
                var locationId = (int)_locationsService.GetByName(locationName)?.Id;

                var advertisingInLocation = _advertisingInLocationRepository.GetByIdFromRepository(locationId);

                return advertisingInLocation?.AdvertisingIds
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

        public int ReplaceRepository(IReadOnlyList<AdvertisingInLocation> newEntitiesList)
        {
            _advertisingInLocationRepository.ReplaceRepository(newEntitiesList);
            return newEntitiesList.Count;
        }
    }
}
