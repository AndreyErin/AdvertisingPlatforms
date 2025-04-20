using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.Domain.Configuration
{
    /// <summary>
    /// Сlass provides access to the configuration file parameter.
    /// </summary>
    public class Config: IConfig
    {
        private static string _apDbPath = "";
        private static string _lDbPath = "";
        private static bool isInicialize = false;

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
            if (isInicialize)
            {
                return;
            }

            string? apDbPath = configuration.GetSection("DataBases:AdvertisingPlatforms").Value;

            string? lDbPath = configuration.GetSection("DataBases:Locations").Value;

            if (apDbPath != null && lDbPath != null)
            {
                _apDbPath = apDbPath;
                _lDbPath = lDbPath;

                isInicialize = true;
            }
            else
            {
                throw new ConfigureReadExeption("Не удалось получить пути к json-базам данных из файла конфигурации.");
            }

        }

    }
}
