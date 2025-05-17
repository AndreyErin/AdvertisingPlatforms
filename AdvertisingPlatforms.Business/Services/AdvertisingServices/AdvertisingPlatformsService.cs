using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{

    /// <summary>
    /// Service for advertising platforms.
    /// </summary>
    public class AdvertisingPlatformsService : IAdvertisingPlatformsService
    {
        private readonly Repository<AdvertisingPlatform> _advertisingPlatformPlatformsRepository;

        public AdvertisingPlatformsService(Repository<AdvertisingPlatform> advertisingPlatformsRepository)
        {
            _advertisingPlatformPlatformsRepository = advertisingPlatformsRepository;
        }

        /// <summary>
        /// Get advertising platform by ID.
        /// </summary>
        /// <param name="id">ID of advertising platform.</param>
        /// <returns>Advertising platform or null.</returns>
        /// <exception cref="BusinessException"></exception>
        public AdvertisingPlatform? GetById(int id)
        {
            try
            {
                return _advertisingPlatformPlatformsRepository.GetByIdFromRepository(id);
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
        public int ReplaceRepository(IReadOnlyList<AdvertisingPlatform> newEntitiesList)
        {
            try
            {
                _advertisingPlatformPlatformsRepository.ReplaceRepository(newEntitiesList);

                return newEntitiesList.Count;
            }
            catch (Exception ex)
            {
                throw new BusinessException(
                    ErrorConstants.ServiceReplaceRepository,
                    ex);
            }
        }
    }
}
