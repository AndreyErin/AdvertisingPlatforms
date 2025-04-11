namespace AdvertisingPlatforms.Domain.Interfaces
{

    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IPlatformsService
    {
        /// <summary>
        /// Get advertising platforms for location.
        /// </summary>
        /// <param name="location">Location for Advertising.</param>
        /// <returns>Return count advertising platforms for location.</returns>
        public List<string> GetPlatforms(string locationName);

        /// <summary>
        /// Set new database for PlatformsService.
        /// </summary>
        /// <param name="newDb">New database for update.</param>
        /// <returns>Return count elements of database for success, -1 for fail.</returns>
        public int SetDbPlatforms(Dictionary<string, List<string>> newDb);
    }
}
