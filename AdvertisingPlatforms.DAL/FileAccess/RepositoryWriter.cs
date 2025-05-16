using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;

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
        /// <exception cref="BusinessException"></exception>
        public void SaveChangesToFile<TResource>(string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : Resource
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentException(ErrorConstants.Argument + " - " + nameof(filePath));
                if (newDataForDb.Count == 0) 
                    throw new ArgumentException(ErrorConstants.Argument + " - " + nameof(newDataForDb));

                var newDbJson = JsonSerializer.Serialize(newDataForDb, new JsonSerializerOptions() { WriteIndented = true });

                using StreamWriter sw = new StreamWriter(Path.Combine(AppContext.BaseDirectory, filePath), false);

                sw.Write(newDbJson);

            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorConstants.WriteRepository, ex);
            }
        }
    }
}
