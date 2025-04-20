using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;

namespace AdvertisingPlatforms.Domain.Extensions
{
    public static class FileRepositoryExtensions
    {
        /// <summary>
        /// Method for reading all entities from json-file.
        /// </summary>
        /// <typeparam name="T">notnull, Resource</typeparam>
        /// <param name="fileRepository"></param>
        /// <param name="filePath">Path for file with data.</param>
        /// <returns>List of entities.</returns>
        public static List<T> GetAllFromFile<T>(this FileRepository<T> fileRepository, string filePath) where T : notnull, Resource
        {
            using StreamReader sr = new StreamReader(filePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<List<T>>(jsonDb);

            if (result == null)
            {
                //Exeption
            }

            return result;
        }

        /// <summary>
        /// Method for writing all entities to json-file.
        /// </summary>
        /// <typeparam name="T">notnull, Resource</typeparam>
        /// <param name="fileRepository"></param>
        /// <param name="filePath">Path for file.</param>
        /// <param name="newDataForDb">List of entities for writing.</param>
        public static void SaveChangesToFile<T>(this FileRepository<T> fileRepository, string filePath, List<T> newDataForDb) where T : notnull, Resource
        {
            var newDbJson = JsonSerializer.Serialize(newDataForDb);

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
