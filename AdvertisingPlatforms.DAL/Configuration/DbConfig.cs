using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exeptions;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Configuration
{
    /// <summary>
    /// Class provides access to the configuration file parameter.
    /// </summary>
    public static class DbConfig
    {
        private static Lazy<string> _advertisingInLocationDbPath;
        private static Lazy<string> _advertisingPlatformsDbPath;
        private static Lazy<string> _locationsDbPath;
        private static bool _initialized = false;

        /// <summary>
        /// Path for database AdvertisingInLocation.
        /// </summary>
        public static string AdvertisingInLocationDbPath => _initialized
            ? _advertisingInLocationDbPath.Value
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Path for database AdvertisingPlatforms.
        /// </summary>
        public static string AdvertisingPlatformsDbPath =>  _initialized
            ? _advertisingPlatformsDbPath.Value 
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationsDbPath => _initialized 
            ? _locationsDbPath.Value 
            : Error(ErrorConstants.ConfigNotInitialized);

        

        /// <summary>
        /// Initialize configuration.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public static void Initialize(IConfiguration configuration)
        {
            if (_initialized) return;

            _advertisingInLocationDbPath = new Lazy<string>(() =>
                configuration.GetSection("DataBases:AdvertisingInLocation").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _advertisingPlatformsDbPath = new Lazy<string>(() =>
                configuration.GetSection("DataBases:AdvertisingPlatforms").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _locationsDbPath = new Lazy<string>(() =>
                configuration.GetSection("DataBases:Locations").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _initialized = true;
        }

        private static string Error(string message) => throw new BusinessException(message);

    }
}
