using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for managing locations.
    /// </summary>
    public interface ILocationsService: IReplaceData<Location>
    {
        /// <summary>
        /// Get id location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns>Return location or null.</returns>
        public Location? GetByName(string name);

        /// <summary>
        /// Get location by ID.
        /// </summary>
        /// <param name="id">ID of location.</param>
        /// <returns>Location.</returns>
        /// <exception cref="BusinessException"></exception>
        public Location? GetById(int id);
    }
}
