using System.Diagnostics.CodeAnalysis;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;

namespace AdvertisingPlatforms.DAL.FileAccess.Extensions
{
    public static class RepositoryReaderExtensions
    {
        /// <summary>
        /// Checking the possibility to get the data.
        /// </summary>
        /// <typeparam name="TResource">Resource</typeparam>
        /// <param name="repositoryReader"></param>
        /// <param name="filePath">Path for file.</param>
        /// <param name="data">Data from repository.</param>
        /// <returns></returns>
        public static bool TryReadData<TResource>(this RepositoryReader repositoryReader, string filePath,[NotNullWhen(true)] out List<TResource>? data) where TResource : Resource
        {
            data = null;

            try
            {
                using StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, filePath));
                var jsonDb = sr.ReadToEnd();

                if (string.IsNullOrEmpty(jsonDb))
                    return false;

                data = JsonSerializer.Deserialize<List<TResource>>(jsonDb);

                return data != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
