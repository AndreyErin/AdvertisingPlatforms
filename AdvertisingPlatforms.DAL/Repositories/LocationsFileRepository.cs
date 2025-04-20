using AdvertisingPlatforms.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsFileRepository : FileRepository<Location>
    {       
        public LocationsFileRepository(IConfiguration configuration)
        {
            string? dbFilePath = configuration.GetSection("DataBases:Locations").Value;

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
