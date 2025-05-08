using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Configuration
{
    /// <summary>
    /// Class provides access to the configuration file parameter.
    /// </summary>
    public static class DbConfig
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
