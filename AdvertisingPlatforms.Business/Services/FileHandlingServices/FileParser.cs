using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;
using System.Text.RegularExpressions;

namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Parser for file.
    /// </summary>
    public class FileParser : IFileParser
    {
        private readonly Regex _regex = new(FileConstants.RowPattern);

        /// <summary>
        /// Parsing data from file.
        /// </summary>
        /// <param name="fileContent">Content from file.</param>
        /// <returns>Data.</returns>
        public AdvertisingInformation GetParseData(string fileContent)
        {
            var dictionaryFileContent = GetDictionaryFileContent(fileContent);

            var advertisingPlatforms = dictionaryFileContent
                .SelectMany(x => x.Value)
                .Distinct()
                .Select((x, Index) => new AdvertisingPlatform(Index + 1) { Name = x });

            var locations = dictionaryFileContent
                .Select((x, Index) => new Location(Index + 1) { Name = x.Key });

            var advertisingsInLocation =
                GetAdvertisingsInLocations(dictionaryFileContent, advertisingPlatforms, locations);

            return new(advertisingsInLocation.ToList(),advertisingPlatforms.ToList(), locations.ToList());
        }

        private IEnumerable<AdvertisingsInLocation> GetAdvertisingsInLocations(
              IEnumerable<KeyValuePair<string,
              IEnumerable<string>>> dictionaryFileContent, 
              IEnumerable<AdvertisingPlatform> advertisingPlatforms, IEnumerable<Location> locations)
        {
            return dictionaryFileContent
                .Select((x, Index) => new AdvertisingsInLocation(
                    Index + 1,
                    locations.First(y=>y.Name == x.Key).Id,
                    advertisingPlatforms
                        .Join(x.Value, a => a.Name , d=>d , (a, d) => a.Id )
                        .ToList()
                ));
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetDictionaryFileContent(string fileContent)
        {
            var dictionaryFileContent = fileContent
                .Split(FileConstants.RowsSplitter)
                .Where(x => _regex.IsMatch(x))
                .Select(x => x.Split(FileConstants.Splitter))
                .Where(x => x.Length == 2)
                .Select(x =>
                    AddDirectAdvertising(x[0].Trim(), x[1].Split(FileConstants.EntitiesSplitter))
                )
                .SelectMany(x => x);

            return AddAdditionalAdvertising(dictionaryFileContent);
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> AddDirectAdvertising(string advertisingPlatformName, IEnumerable<string> locationNames)
        {
            return locationNames
                .Select(x => new KeyValuePair<string,IEnumerable<string>>(x, [advertisingPlatformName]));
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> AddAdditionalAdvertising(IEnumerable<KeyValuePair<string, IEnumerable<string>>> dictionaryData)
        {
            return dictionaryData
                .Select(x => new KeyValuePair<string, IEnumerable<string>>(x.Key, GetAllAdvertisingsForLocation(x.Key, dictionaryData)));
        }

        private IEnumerable<string> GetAllAdvertisingsForLocation(string locationName, IEnumerable<KeyValuePair<string, IEnumerable<string>>> dictionaryData)
        {
            return dictionaryData
                .Where(x => locationName.Contains(x.Key))
                .Select(x => x.Value.First())
                .Distinct();
        }


    }
}
