using AdvertisingPlatforms.Business.ServiceCollection;
using AdvertisingPlatforms.DAL.ServiceCollection;
using AdvertisingPlatforms.ServiceCollection;

namespace AdvertisingPlatforms.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application builder.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Configure web application builder.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public static void ConfigureBuilder(this WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();

            builder.Services.AddAdvertisingServices();
            builder.Services.AddRepositoryServices();
            builder.Services.AddFileServices();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddSwaggerServices();
            }
        }
    }
}
