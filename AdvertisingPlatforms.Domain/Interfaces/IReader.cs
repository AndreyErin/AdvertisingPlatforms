using AdvertisingPlatforms.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    /// <summary>
    /// Interface for reader of files.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Convert txt-file to DataFromFile.
        /// </summary>
        /// <param name="file">File for convert.</param>
        /// <returns>Returns DataFromFile for success, null for fail.</returns>
        public Task<DataFromFile?> GetDataFromFileAsync(IFormFile file);
    }
}
