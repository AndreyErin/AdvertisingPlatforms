using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Extensions
{
    public static class LocationFileRepositoryExtensions
    {
        /// <summary>
        /// Get entity by name form repository.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="name">name of entity.</param>
        /// <returns>Entity for success, null for fail</returns>
        public static Location? GetByNameFromRepository(this Repository<Location> repository, string name)
        {
            return repository.RepositoryReader.GetAllFromFile<Location>(repository.FileRepository.FilePath).Find(x => x.Name == name);
        }
    }
}
