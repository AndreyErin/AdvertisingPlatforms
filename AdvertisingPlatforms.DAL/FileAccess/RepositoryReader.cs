using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Resources;
using AdvertisingPlatforms.Domain.Exeptions;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    public class RepositoryReader: IRepositoryReader
    {
        /// <summary>
        /// Method for reading all entities from json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="filePath">Path for file with data.</param>
        /// <returns>List of entities.</returns>
        public  List<TResource> GetAllFromFile<TResource>(string filePath) where TResource : Resource
        {
            try
            {
                if (string.IsNullOrEmpty(filePath)) 
                    throw new ArgumentException(Messages.Error.Argument + " - " + nameof(filePath));

                using StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, filePath));
                var jsonDb = sr.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<TResource>>(jsonDb);

                return result;
            }
            catch (Exception ex)
            {
                throw new ReadRepositoryExeption(Messages.Error.ReadRepository, ex);
            }
        }
    }
}
