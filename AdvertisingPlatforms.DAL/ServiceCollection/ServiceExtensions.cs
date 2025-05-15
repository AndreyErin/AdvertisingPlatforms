using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.DAL.FileAccess;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingPlatforms.DAL.ServiceCollection
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration repository services
        /// </summary>
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryReader, RepositoryReader>();
            services.AddScoped<IRepositoryWriter, RepositoryWriter>();
            services.AddScoped<Repository<Location>, LocationsFileRepository>();
            services.AddScoped<Repository<AdvertisingPlatform>, AdvertisingPlatformsFileRepository>();
        }
    }
}
