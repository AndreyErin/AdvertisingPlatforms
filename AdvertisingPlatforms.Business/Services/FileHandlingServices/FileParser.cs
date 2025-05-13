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
        /// <summary>
        /// Parsing data from file.
        /// </summary>
        /// <param name="fileContent">Content from file.</param>
        /// <returns>Data.</returns>
        public AdvertisingInformation GetParseData(string fileContent)
        {
            var regex = new Regex(@"^[А-Яа-я.\- ]+:[A-Za-z,\/]+$");

            var advertisingPlatformsAndLocationRaw = fileContent
                .Split("\r\n")
                .Where(x=> regex.IsMatch(x))
                .Select(x => x.Split(":"))
                .Where(x => x.Length == 2)
                .Select((x, Index) => new
                {
                    advertisingPlatforms = new AdvertisingPlatform(Index + 1) { Name = x[0].Trim() },
                    locationsRaw = GetLocationsRaw(x[0].Trim(), x[1].Split(",").ToList())
                });

            var advertisingPlatforms = advertisingPlatformsAndLocationRaw
                .Select(x=> x.advertisingPlatforms)
                .ToList();

            var locationsRaw = advertisingPlatformsAndLocationRaw
                .SelectMany(x => x.locationsRaw)
                .ToDictionary();


            var locations = GetLocations(locationsRaw, advertisingPlatforms);

            return new(advertisingPlatforms, locations);
        }

        private Dictionary<string,string> GetLocationsRaw(string advertisingPlatformName, List<string> locationNames)
        {
            return locationNames
                .Select(x => new KeyValuePair<string,string>(x, advertisingPlatformName))
                .ToDictionary();
        }

        private List<Location> GetLocations(Dictionary<string, string> locationsRaw,
            List<AdvertisingPlatform> advertisingPlatforms)
        {
            var locations = locationsRaw
                .Select((x, Index) => new Location(Index + 1)
                {
                    Name = x.Key,
                    AdvertisingPlatformIds = GetDirectId(advertisingPlatforms, x.Value) > 0
                        ? [GetDirectId(advertisingPlatforms, x.Value)]
                        : new()
                })
                .ToList();

            locations.ForEach(x=> x.AdvertisingPlatformIds.AddRange(GetAdditionalIds(locationsRaw, advertisingPlatforms, x.Name)));    

            return locations;
        }

        private int GetDirectId(List<AdvertisingPlatform> advertisingPlatforms, string currentAdvertisingPlatorm)
        {
            return advertisingPlatforms.Find(x => x.Name == currentAdvertisingPlatorm)?.Id ?? 0;
        }

        private List<int> GetAdditionalIds(Dictionary<string, string> locationsRaw, List<AdvertisingPlatform> advertisingPlatforms, string currentAdvertisingPlatorm)
        {
            return locationsRaw.Where(x => currentAdvertisingPlatorm.Contains(x.Key) && x.Key != currentAdvertisingPlatorm)
                               .Select(x => x.Value)
                               .Join(advertisingPlatforms, x => x, y => y.Name, (x, y) => y.Id)
                               .ToList();
        }
    }
}
