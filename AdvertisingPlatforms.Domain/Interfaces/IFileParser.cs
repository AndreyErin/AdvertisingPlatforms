using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    public interface IFileParser
    {
        public DataFromFile? GetParseData(string fileContent);
    }
}
