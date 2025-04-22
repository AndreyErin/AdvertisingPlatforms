using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    public interface IFileParser
    {
        public AdvertisingInformation? GetParseData(string fileContent);
    }
}
