
namespace AdvertisingPlatforms.Models
{
    public class PlatformsService : IPlatformsService
    {
        public List<string> GetPlatforms(string region)
        {
            return new List<string>() { region };
        }

        public async Task SetPlatformsFromFile(FileStream dataFile)
        {
            throw new NotImplementedException();
        }
    }
}
