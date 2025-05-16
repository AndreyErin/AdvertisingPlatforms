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
        private static Lazy<string> _advertisingPlatformsDbPath;
        private static Lazy<string> _locationsDbPath;

        /// <summary>
        /// Path for database AdvertisingPlatforms.
        /// </summary>
        public static string AdvertisingPlatformsDbPath => _advertisingPlatformsDbPath.Value;

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationsDbPath => _locationsDbPath.Value;

        /// <summary>
        /// Initialize configuration.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public static void Initialize(IConfiguration configuration)
        {
            _advertisingPlatformsDbPath = new Lazy<string>(()=> 
                configuration.GetSection("DataBases:AdvertisingPlatforms").Value ??
                throw new BusinessException(ErrorConstants.ConfigurationRead));

            _locationsDbPath = new Lazy<string>(()=> 
                configuration.GetSection("DataBases:Locations").Value ??
                throw new BusinessException(ErrorConstants.ConfigurationRead));
        }
    }
}
