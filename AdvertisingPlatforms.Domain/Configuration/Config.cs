using AdvertisingPlatforms.Domain.Exeptions;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.Domain.Configuration
{
    /// <summary>
    /// Сlass provides access to the configuration file parameter.
    /// </summary>
    public class Config
    {
        private static string _apDbPath = "";
        private static string _lDbPath = "";
        private static bool _isInicialize = false;

        /// <summary>
        /// Path for database AcdvertisingPlatforms.
        /// </summary>
        public static string AdvertisingPlatformsDbPath { get { return _apDbPath; } }

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationsDbPath { get {return _lDbPath; } }

        
        public Config(IConfiguration configuration)
        {
            if (_isInicialize)
            {
                return;
            }

            string? apDbPath = configuration.GetSection("DataBases:AdvertisingPlatforms").Value;

            string? lDbPath = configuration.GetSection("DataBases:Locations").Value;

            if (apDbPath != null && lDbPath != null)
            {
                _apDbPath = apDbPath;
                _lDbPath = lDbPath;

                _isInicialize = true;
            }
            else
            {
                throw new ConfigureReadExeption("Не удалось получить пути к json-базам данных из файла конфигурации.");
            }

        }

    }
}
