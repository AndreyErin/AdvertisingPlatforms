using AdvertisingPlatforms.Domain.Models.BaseModels;
using AdvertisingPlatforms.Business.Abstractions.Repositories;
using System.Text.Json;

namespace AdvertisingPlatforms.Business.Extensions
{
    public static class FileRepositoryExtensions
    {
        /// <summary>
        /// Method for reading all entities from json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="fileRepository"></param>
        /// <param name="filePath">Path for file with data.</param>
        /// <returns>List of entities.</returns>
        public static List<TResource> GetAllFromFile<TResource>(this FileRepository<TResource> fileRepository, string filePath) where TResource : notnull, Resource
        {
            using StreamReader sr = new StreamReader(filePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<List<TResource>>(jsonDb);

            if (result == null)
            {
                //Exeption
            }

            return result;
        }

        /// <summary>
        /// Method for writing all entities to json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="fileRepository"></param>
        /// <param name="filePath">Path for file.</param>
        /// <param name="newDataForDb">List of entities for writing.</param>
        public static void SaveChangesToFile<TResource>(this FileRepository<TResource> fileRepository, string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : notnull, Resource
        {
            var newDbJson = JsonSerializer.Serialize(newDataForDb, new JsonSerializerOptions() { WriteIndented = true });

            if (newDbJson != null)
            {
                using StreamWriter sw = new StreamWriter(filePath, false);

                sw.Write(newDbJson);
            }
            else
            {
                //Exeption
            }
        }
    }
}
