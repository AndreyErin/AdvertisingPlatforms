using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsFileRepository : Repository<Location>
    {
        /// <summary>
        /// Create repository for locations.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public LocationsFileRepository(
            IRepositoryReader repositoryReader,
            IRepositoryWriter repositoryWriter) : base(repositoryReader, repositoryWriter) { }

        /// <summary>
        /// Get entity by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>Entity for success, null for fail</returns>
        public Location? GetByNameFromRepository(string name)
        {
            return _repositoryReader.GetAllFromFile<Location>(_repository._filePath).Find(x => x.Name == name);
        }
    }
}
