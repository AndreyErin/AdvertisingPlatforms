using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{

    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IAdvertisingPlatformsService: IReplaceData<AdvertisingPlatform>
    {
        /// <summary>
        /// Get advertising platforms for location.
        /// </summary>
        /// <param name="location">Location for Advertising platforms.</param>
        /// <returns>Return count advertising platforms for location.</returns>
        public List<string> GetAdvertisingPlatformsForLocation(string locationName);

    }
}
