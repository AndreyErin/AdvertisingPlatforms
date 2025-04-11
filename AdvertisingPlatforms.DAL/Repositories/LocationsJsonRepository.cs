using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsJsonRepository : Repository<Location> //ILocationsRepository
    {       
        public LocationsJsonRepository()
        {
            filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\LocationsDb.json";
        }      
    }
}
