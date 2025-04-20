using AdvertisingPlatforms.Domain.Configuration;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingPlatforms for working with a json file.
    /// </summary>
    public class AdvertisingPlatformsFileRepository : FileRepository<AdvertisingPlatform>
    {
        public AdvertisingPlatformsFileRepository(Config _)
        {
            _dbFilePath = Config.AdvertisingPlatformsDbPath;
        }
    }
}
