using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces
{

    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IAdvertisingPlatformsService
    {
        /// <summary>
        /// Get advertising platforms for location.
        /// </summary>
        /// <param name="location">Location for Advertising platforms.</param>
        /// <returns>Return count advertising platforms for location.</returns>
        public List<string> GetAdvertisingPlatformsForLocation(string locationName);

        /// <summary>
        /// Set new database for PlatformsService.
        /// </summary>
        /// <param name="newDb">New database for update.</param>
        /// <returns>Return count elements of database for success, -1 for fail.</returns>
        public int ReplaceAllRepositoryData(DataFromFile newDата);
    }
}
