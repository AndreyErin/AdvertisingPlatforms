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
    }
}
