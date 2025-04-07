namespace AdvertisingPlatforms.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface for platforms repository.
    /// </summary>
    public interface IPlatformsRepository
    {
        /// <summary>
        /// Get database for PlatformService
        /// </summary>
        /// <returns>Return database for success, null for fail.</returns>
        Dictionary<string, List<string>>? GetDb();

        /// <summary>
        /// Set new database for PlatformService.
        /// </summary>
        /// <param name="newDb">New database for update.</param>
        /// <returns>Return count elements of database for success, -1 for fail.</returns>
        int SetDb(Dictionary<string, List<string>> newDb);
    }
}
