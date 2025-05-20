namespace AdvertisingPlatforms.ServiceCollection
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration file services
        /// </summary>
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                var xmlFile = @"AdvertisingPlatforms.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                var xmlFileDomain = @"AdvertisingPlatforms.Domain.xml";
                var xmlPathDomain = Path.Combine(AppContext.BaseDirectory, xmlFileDomain);
                options.IncludeXmlComments(xmlPathDomain);
            });
        }
    }
}
