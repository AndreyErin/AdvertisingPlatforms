using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Interfaces;
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
            services.AddScoped<IPlatformsService, PlatformsService>();
            services.AddScoped<IReader, FileReader>();
            services.AddScoped<FileRepository<Location>, LocationsFileRepository>();
            services.AddScoped<FileRepository<Advertising>, AdvertisingsFileRepository>();

            return services;
        }
    }
}
