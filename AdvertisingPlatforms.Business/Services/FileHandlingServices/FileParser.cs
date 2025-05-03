using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Parcer for file.
    /// </summary>
    public class FileParser : IFileParser
    {
        /// <summary>
        /// Parsing data from file.
        /// </summary>
        /// <param name="fileContent">Content from file.</param>
        /// <returns>Get data or exeption.</returns>
        public AdvertisingInformation GetParseData(string fileContent)
        {
            var advertisingPlatformsAndLocationRaw = fileContent
                .Split("\r\n")
                .Select(x => x.Split(":"))
                .Where(x => x.Length == 2)
                .Select((x, Index) => new
                {
                    advertisingPlatforms = new AdvertisingPlatform { Id = Index + 1, Name = x[0].Trim() },
                    locationsRaw = GetLocationsRaw(x[0].Trim(), x[1].Split(",").ToList())
                })
                .ToList();

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
                .Select((x, Index) => new Location
                {
                    Id = Index + 1,
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
