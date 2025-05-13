using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.DAL.Resources;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingPlatformsService : IAdvertisingPlatformsService
    {
        private readonly Repository<AdvertisingPlatform> _advertisingPlatformPlatformsRepository;
        private readonly ILocationsService _locationsService;

        public AdvertisingPlatformsService(Repository<AdvertisingPlatform> advertisingPlatformsRepository,
                                           ILocationsService locationsService)
        {
            _locationsService = locationsService;
            _advertisingPlatformPlatformsRepository = advertisingPlatformsRepository;
        }

        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        /// <exception cref="AdvertisingPlatformsServiceExeption"></exception>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName)
        {
            try
            {
                var location = _locationsService.GetByName(locationName);

                if (location?.AdvertisingPlatformIds.Count > 0)
                {
                    return _advertisingPlatformPlatformsRepository.GetByIdFromRepository(location.AdvertisingPlatformIds)
                        .Select(x => x.Name)
                        .ToList();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new AdvertisingPlatformsServiceExeption(
                    Messages.Error.AdvertisingPlatformsServiceGetData,
                    ex);
            }
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        /// <exception cref="AdvertisingPlatformsServiceExeption"></exception>
        public int ReplaceRepository(IReadOnlyList<AdvertisingPlatform> newEntitiesList)
        {
            try
            {
                _advertisingPlatformPlatformsRepository.ReplaceRepository(newEntitiesList);

                return newEntitiesList.Count;
            }
            catch (Exception ex)
            {
                throw new AdvertisingPlatformsServiceExeption(
                    Messages.Error.AdvertisingPlatformsServiceReplaceRepository,
                    ex);
            }
        }
    }
}
