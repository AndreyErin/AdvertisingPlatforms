using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces
{
    public interface IReader
    {
        public Task<Dictionary<Location, List<Advertising>>?> GetValidDataAsync(IFormFile file);
    }
}
