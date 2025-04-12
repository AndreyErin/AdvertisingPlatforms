using Microsoft.AspNetCore.Http;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    /// <summary>
    /// Interface for reader of files.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Convert txt-file to Dictionary.
        /// </summary>
        /// <param name="file">File for convert.</param>
        /// <returns>Returns Dictionary for success, null for fail.</returns>
        public Task<Dictionary<string, List<string>>?> GetDataFromFileAsync(IFormFile file);
    }
}
