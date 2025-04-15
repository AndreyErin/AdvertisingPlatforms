using AdvertisingPlatforms.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingPlatforms for working with a json file.
    /// </summary>
    public class AdvertisingPlatformsFileRepository : FileRepository<AdvertisingPlatform>
    {
        public AdvertisingPlatformsFileRepository(IConfiguration configuration)
        {
            string? dbFilePath = configuration.GetSection("DataBases:AdvertisingPlatforms").Value;

            if (dbFilePath != null)
            {
                _dbFilePath = dbFilePath;
            }
            else
            {
                //Exeption
            }

        }
    }
}
