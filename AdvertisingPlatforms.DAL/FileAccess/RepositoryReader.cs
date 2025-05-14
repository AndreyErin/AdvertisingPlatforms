using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using AdvertisingPlatforms.DAL.FileAccess.Extensions;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exeptions;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    public class RepositoryReader : IRepositoryReader
    {
        /// <summary>
        /// Method for reading all entities from json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="filePath">Path for file with data.</param>
        /// <returns>List of entities.</returns>
        /// <exception cref="ReadRepositoryExeption"></exception>
        public List<TResource> GetAllFromFile<TResource>(string filePath) where TResource : Resource
        {
            if (this.TryReadData(filePath, out List<TResource>? data))
            {
                return data;
            }
            else
            {
                throw new ReadRepositoryExeption(ErrorConstants.ReadRepository);
            }
        }
    }
}
