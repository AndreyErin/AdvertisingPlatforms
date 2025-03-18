namespace AdvertisingPlatforms.Models
{
    public interface IReader
    {
        public Task<Dictionary<string, string>?> GetValidDataAsync(IFormFile file);
    }
}
