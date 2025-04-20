using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Configuration;
using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Services;

namespace AdvertisingPlatforms.ServiceCollection
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration collection of service
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisingPlatformsService, AdvertisingPlatformsService>();
            services.AddScoped<ILocationsService, LocationsService>();

            services.AddScoped<Config>();

            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IFileParser, FileParser>();
            services.AddScoped<IFileValidator, FileValidator>();

            services.AddScoped<FileRepository<Location>, LocationsFileRepository>();
            services.AddScoped<FileRepository<AdvertisingPlatform>, AdvertisingPlatformsFileRepository>();

            return services;
        }
    }
}
