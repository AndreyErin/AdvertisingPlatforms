using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Interfaces
{
    /// <summary>
    /// Interface for repository reader.
    /// </summary>
    public interface IRepositoryReader
    {
        /// <summary>
        /// Get all data from file.
        /// </summary>
        /// <typeparam name="TResource">Resource.</typeparam>
        /// <param name="filePath">Path to file.</param>
        /// <returns>Data from repository.</returns>
        public List<TResource> GetAllFromFile<TResource>(string filePath) where TResource : Resource;

    }
}
