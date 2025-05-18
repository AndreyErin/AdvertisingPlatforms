using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingInLocation for working with a json file.
    /// </summary>
    public class AdvertisingInLocationFileRepository : Repository<AdvertisingInLocation>
    {
        /// <summary>
        /// Create repository for advertising in location.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public AdvertisingInLocationFileRepository(
            IRepositoryReader repositoryReader, 
            IRepositoryWriter repositoryWriter): base(repositoryReader, repositoryWriter) {}
    }
}
