namespace AdvertisingPlatforms.Models
{
    public interface IPlatformsService
    {
        public List<string> GetPlatforms(string region);
        public Task SetPlatformsFromFile(FileStream dataFile);
    }
}
