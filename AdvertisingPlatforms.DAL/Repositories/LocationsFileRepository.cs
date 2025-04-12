using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsFileRepository : FileRepository<Location>
    {       
        public LocationsFileRepository()
        {
            _dbFilePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\LocationsDb.json";
        }      
    }
}
