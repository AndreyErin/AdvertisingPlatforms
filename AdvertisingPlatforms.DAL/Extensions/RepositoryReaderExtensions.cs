using System.Diagnostics.CodeAnalysis;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;
using AdvertisingPlatforms.DAL.FileAccess;

namespace AdvertisingPlatforms.DAL.Extensions
{
    public static class RepositoryReaderExtensions
    {
        /// <summary>
        /// Checking the possibility to get the data.
        /// </summary>
        /// <typeparam name="TResource">Resource</typeparam>
        /// <param name="_"></param>
        /// <param name="filePath">Path for file.</param>
        /// <param name="data">Data from repository.</param>
        /// <returns></returns>
        public static bool TryReadData<TResource>(this RepositoryReader _, string filePath, [NotNullWhen(true)] out List<TResource>? data) where TResource : Resource
        {
            data = null;

            using StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, filePath));
            var jsonDb = sr.ReadToEnd();

            if (string.IsNullOrEmpty(jsonDb))
            {
                
                return false;
            }

            try
            {
                data = JsonSerializer.Deserialize<List<TResource>>(jsonDb);

                return data != null;
            }
            catch (JsonException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }
    }
}
