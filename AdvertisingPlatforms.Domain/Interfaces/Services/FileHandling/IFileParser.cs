using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling
{
    public interface IFileParser
    {
        public AdvertisingInformation? GetParseData(string fileContent);
    }
}
