using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisings for working with a json file.
    /// </summary>
    public class AdvertisingsJsonRepository : Repository<Advertising> //IAdvertisingsRepository
    {
        public AdvertisingsJsonRepository()
        {
            filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\AdvertisingsDb.json";
        }     
    }
}
