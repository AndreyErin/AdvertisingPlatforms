using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisings for working with a json file.
    /// </summary>
    public class AdvertisingsFileRepository : FileRepository<Advertising>
    {
        public AdvertisingsFileRepository()
        {
            _dbFilePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\AdvertisingsDb.json";
        }     
    }
}
