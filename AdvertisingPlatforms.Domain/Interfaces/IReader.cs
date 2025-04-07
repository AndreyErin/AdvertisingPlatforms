using Microsoft.AspNetCore.Http;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    public interface IReader
    {
        public Task<Dictionary<string, List<string>>?> GetValidDataAsync(IFormFile file);
    }
}
