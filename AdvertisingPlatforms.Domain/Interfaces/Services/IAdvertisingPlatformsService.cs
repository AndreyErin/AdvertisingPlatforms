using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IAdvertisingPlatformsService: IReplaceData<AdvertisingPlatform>
    {
        /// <summary>
        /// Get advertising platform by ID.
        /// </summary>
        /// <param name="id">ID of advertising platform.</param>
        /// <returns>Advertising platform or null.</returns>
        /// <exception cref="BusinessException"></exception>
        public AdvertisingPlatform? GetById(int id);
    }
}
