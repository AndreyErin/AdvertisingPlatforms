using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    /// <summary>
    /// Parser for data from file.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Get parsed data from file.
        /// </summary>
        /// <param name="fileContent">Content from file.</param>
        /// <returns>Parsed data from file.</returns>
        public DataFromFile GetParsedData(string fileContent);
    }
}
