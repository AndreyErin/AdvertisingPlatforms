using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;
using System.Text.RegularExpressions;
using AdvertisingPlatforms.DAL.Const;

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
            var advertisingPlatformsAndLocationsRaw = SplitIntoPlatformAndLocationsRaw(fileContent);

            var advertisingPlatforms = advertisingPlatformsAndLocationsRaw
                .Select(x => x.advertisingPlatforms);

            var locationsRaw = advertisingPlatformsAndLocationsRaw
                .SelectMany(x => x.locationsRaw);

            var locations = GetLocations(locationsRaw, advertisingPlatforms);

            return new(advertisingPlatforms.ToList(), locations.ToList());
        }

        private IEnumerable<(AdvertisingPlatform advertisingPlatforms,
            IEnumerable<KeyValuePair<string, string>> locationsRaw)>
            SplitIntoPlatformAndLocationsRaw(string fileContent)
        {
            return fileContent
                .Split(FileConstants.RowsSplitter)
                .Where(x => _regex.IsMatch(x))
                .Select(x => x.Split(FileConstants.Splitter))
                .Where(x => x.Length == 2)
                .Select((x, Index) =>
                (
                    advertisingPlatforms: new AdvertisingPlatform(Index + 1) { Name = x[0].Trim() },
                    locationsRaw: GetLocationsRaw(x[0].Trim(), x[1].Split(FileConstants.EntitiesSplitter).ToList())
                ));
        }

        private IEnumerable<KeyValuePair<string, string>> GetLocationsRaw(string advertisingPlatformName, List<string> locationNames)
        {
            return locationNames
                .Select(x => new KeyValuePair<string,string>(x, advertisingPlatformName));
        }

        private IEnumerable<Location> GetLocations(IEnumerable<KeyValuePair<string, string>> locationsRaw,
            IEnumerable<AdvertisingPlatform> advertisingPlatforms)
        {
            var locations = locationsRaw
                .Select((x, Index) => new Location(Index + 1)
                {
                    Name = x.Key,
                    AdvertisingPlatformIds = GetDirectId(advertisingPlatforms, x.Value) > 0
                        ? [GetDirectId(advertisingPlatforms, x.Value)]
                        : new()
                })
                .Select(x => new Location(x.Id)
                {
                    Name = x.Name,
                    AdvertisingPlatformIds = x.AdvertisingPlatformIds
                        .Union(GetAdditionalIds(locationsRaw, advertisingPlatforms, x.Name))
                        .ToList()
                });

            return locations;
        }

        private int GetDirectId(IEnumerable<AdvertisingPlatform> advertisingPlatforms, string currentAdvertisingPlatorm)
        {
            return advertisingPlatforms.FirstOrDefault(x => x.Name == currentAdvertisingPlatorm)?.Id ?? 0;
        }

        private IEnumerable<int> GetAdditionalIds(IEnumerable<KeyValuePair<string, string>> locationsRaw, IEnumerable<AdvertisingPlatform> advertisingPlatforms, string currentAdvertisingPlatorm)
        {
            return locationsRaw.Where(x =>
                                        currentAdvertisingPlatorm.Contains(x.Key) && x.Key != currentAdvertisingPlatorm)
                               .Select(x => x.Value)
                               .Join(advertisingPlatforms, x => x, y => y.Name, (x, y) => y.Id);
        }
    }
}
