using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingPlatforms for working with a json file.
    /// </summary>
    public class AdvertisingPlatformsFileRepository : Repository<AdvertisingPlatform>
    {
        /// <summary>
        /// Create repository for advertising platforms.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public AdvertisingPlatformsFileRepository(
            IRepositoryReader repositoryReader, 
            IRepositoryWriter repositoryWriter): base(repositoryReader, repositoryWriter) {}
    }
}
