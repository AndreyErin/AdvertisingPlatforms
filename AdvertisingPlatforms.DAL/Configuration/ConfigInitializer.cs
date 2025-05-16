using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AdvertisingPlatforms.DAL.Configuration
{
    /// <summary>
    /// Initializer for DbConfig.
    /// </summary>
    public class ConfigInitializer: IHostedService
    {
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Create initializer for DbConfig.
        /// </summary>
        public ConfigInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method at startup.
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            DbConfig.Initialize(_configuration);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Method with stopping.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
