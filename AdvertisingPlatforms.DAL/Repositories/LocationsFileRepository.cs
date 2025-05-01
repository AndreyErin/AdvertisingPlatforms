using AdvertisingPlatforms.Business.Abstractions.Repositories;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsFileRepository : FileRepository<Location>
    {       
        public LocationsFileRepository(Config _)
        {
            _dbFilePath = Config.LocationsDbPath;
        }      
    }
}
