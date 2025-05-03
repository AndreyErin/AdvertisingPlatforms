using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.Domain.Configuration
{
    /// <summary>
    /// Class provides access to the configuration file parameter.
    /// </summary>
    public static class Config
    {
        private static string _advertisingPlatformsDbPath = String.Empty;
        private static string _locationsDbPath = String.Empty;

        /// <summary>
        /// Path for database AdvertisingPlatforms.
        /// </summary>
        public static string AdvertisingPlatformsDbPath => _advertisingPlatformsDbPath;

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationsDbPath => _locationsDbPath;

        /// <summary>
        /// Initialize configuration.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        /// <exception cref="ConfigureReadExeption">Couldn't read the configuration file.</exception>
        public static void Initialize(IConfiguration configuration)
        {
            string? apDbPath = configuration.GetSection("DataBases:AdvertisingPlatforms").Value;

            string? lDbPath = configuration.GetSection("DataBases:Locations").Value;

            if (apDbPath != null && lDbPath != null)
            {
                _advertisingPlatformsDbPath = apDbPath;
                _locationsDbPath = lDbPath;
            }
        }
    }
}
