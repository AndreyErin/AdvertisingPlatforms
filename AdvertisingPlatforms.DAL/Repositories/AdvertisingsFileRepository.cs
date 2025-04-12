using AdvertisingPlatforms.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisings for working with a json file.
    /// </summary>
    public class AdvertisingsFileRepository : FileRepository<Advertising>
    {
        public AdvertisingsFileRepository(IConfiguration configuration)
        {
            string? dbFilePath = configuration.GetSection("DataBases:Advertisings").Value;

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
