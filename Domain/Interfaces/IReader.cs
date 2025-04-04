using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces
{
    public interface IReader
    {
        public Task<Dictionary<string, string>?> GetValidDataAsync(IFormFile file);
    }
}
