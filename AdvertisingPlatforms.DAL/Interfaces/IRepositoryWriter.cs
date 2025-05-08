using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Interfaces
{
    /// <summary>
    /// Interface for repository writer.
    /// </summary>
    public interface IRepositoryWriter
    {
        /// <summary>
        /// Replace data for repository.
        /// </summary>
        /// <typeparam name="TResource">Resource.</typeparam>
        /// <param name="filePath">Path to file.</param>
        /// <param name="newDataForDb">New data for repository.</param>
        public void SaveChangesToFile<TResource>(string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : Resource;

    }
}
