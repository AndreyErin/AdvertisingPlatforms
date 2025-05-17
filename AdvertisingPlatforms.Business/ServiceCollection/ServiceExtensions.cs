using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Business.Services.AdvertisingServices;
using AdvertisingPlatforms.Business.Services.FileHandlingServices;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingPlatforms.Business.ServiceCollection
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration advertising services
        /// </summary>
        public static void AddAdvertisingServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisingPlatformsService, AdvertisingPlatformsService>();
            services.AddScoped<ILocationsService, LocationsService>();
            services.AddScoped<IAdvertisingsInLocationService, AdvertisingsInLocationService>();
        }

        /// <summary>
        /// Method for registration file services
        /// </summary>
        public static void AddFileServices(this IServiceCollection services)
        {
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IFileParser, FileParser>();
            services.AddScoped<IFileValidator, FileValidator>();
        }
    }
}
