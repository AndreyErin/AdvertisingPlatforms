using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Services;
using AdvertisingPlatforms.Domain.Services.FileHandling;

namespace AdvertisingPlatforms.ServiceCollection
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration advertising services
        /// </summary>
        public static IServiceCollection AddAdvertisingServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisingPlatformsService, AdvertisingPlatformsService>();
            services.AddScoped<ILocationsService, LocationsService>();

            return services;
        }

        /// <summary>
        /// Method for registration repository services
        /// </summary>
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<FileRepository<Location>, LocationsFileRepository>();
            services.AddScoped<FileRepository<AdvertisingPlatform>, AdvertisingPlatformsFileRepository>();

            return services;
        }

        /// <summary>
        /// Method for registration file services
        /// </summary>
        public static IServiceCollection AddFileServices(this IServiceCollection services)
        {
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IFileParser, FileParser>();
            services.AddScoped<IFileValidator, FileValidator>();

            return services;
        }
    }
}
