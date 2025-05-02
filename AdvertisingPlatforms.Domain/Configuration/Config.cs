using AdvertisingPlatforms.Domain.Exeptions;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.Domain.Configuration
{
    /// <summary>
    /// Сlass provides access to the configuration file parameter.
    /// </summary>
    public class Config
    {
        private static string _advertisingPlatformsDbPath = String.Empty;
        private static string _locationsDbPath = String.Empty;

        /// <summary>
        /// Path for database AcdvertisingPlatforms.
        /// </summary>
        public static string AdvertisingPlatformsDbPath => _advertisingPlatformsDbPath;

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationsDbPath => _locationsDbPath;

        public Config(IConfiguration configuration)
        {
            string? apDbPath = configuration.GetSection("DataBases:AdvertisingPlatforms").Value;

            string? lDbPath = configuration.GetSection("DataBases:Locations").Value;

            if (apDbPath != null && lDbPath != null)
            {
                _advertisingPlatformsDbPath = apDbPath;
                _locationsDbPath = lDbPath;
            }
            else
            {
                throw new ConfigureReadExeption("Не удалось получить пути к json-базам данных из файла конфигурации.");
            }
        }
    }
}
