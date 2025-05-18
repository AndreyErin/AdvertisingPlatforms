using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdvertisingInLocationService: IReplaceData<AdvertisingInLocation>
    {
        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        /// <exception cref="BusinessException"></exception>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName);
    }
}
