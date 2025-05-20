using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling
{
    /// <summary>
    /// Interface for parser of file.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Get data for fileContent.
        /// </summary>
        /// <param name="fileContent">Content of file.</param>
        /// <returns></returns>
        public AdvertisingInformation GetParseData(string fileContent);
    }
}
