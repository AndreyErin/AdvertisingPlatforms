using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Business.Services.AdvertisingServices;
using AdvertisingPlatforms.Business.Services.FileHandlingServices;
using AdvertisingPlatforms.DAL.Repositories.Base;

namespace AdvertisingPlatforms.ServiceCollection
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration advertising services
        /// </summary>
        public static void AddAdvertisingServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisingPlatformsService, AdvertisingPlatformsService>();
            services.AddScoped<ILocationsService, LocationsService>();
        }

        /// <summary>
        /// Method for registration repository services
        /// </summary>
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<Repository<Location>, LocationsFileRepository>();
            services.AddScoped<Repository<AdvertisingPlatform>, AdvertisingPlatformsFileRepository>();
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

        /// <summary>
        /// Method for registration file services
        /// </summary>
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                var xmlFile = $@"AdvertisingPlatforms.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                var xmlFileDomain = $@"AdvertisingPlatforms.Domain.xml";
                var xmlPathDomain = Path.Combine(AppContext.BaseDirectory, xmlFileDomain);
                options.IncludeXmlComments(xmlPathDomain);
            });
        }
    }
}
