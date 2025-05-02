using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;
using AdvertisingPlatforms.DAL.Interfaces;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    public class RepositoryWriter: IRepositoryWriter
    {
        /// <summary>
        /// Method for writing all entities to json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="filePath">Path for file.</param>
        /// <param name="newDataForDb">List of entities for writing.</param>
        public void SaveChangesToFile<TResource>(string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : Resource
        {
            var newDbJson = JsonSerializer.Serialize(newDataForDb, new JsonSerializerOptions() { WriteIndented = true });

            if (newDbJson.Length > 0)
            {
                using StreamWriter sw = new StreamWriter(Path.Combine(AppContext.BaseDirectory, filePath), false);

                sw.Write(newDbJson);
            }
            else
            {
                //Exeption
            }
        }
    }
}
