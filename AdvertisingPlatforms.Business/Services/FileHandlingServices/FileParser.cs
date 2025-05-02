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
            Dictionary<string, string> locationsRaw = new();
            List<AdvertisingPlatform> advertisingPlatforms = new();

            int idCounter = 1;
            var fileRows = fileContent.Split("\r\n");

            foreach (var row in fileRows)
            {
                var platformAndLocations = row.Split(":");

                if (platformAndLocations.Length == 2)
                {
                    var advertisingPlatformName = platformAndLocations[0].Trim();
                    advertisingPlatforms.Add(new() { Id = idCounter++, Name = advertisingPlatformName });

                    var locationNames = platformAndLocations[1].Split(",").ToList();
                    AddLocationsRaw(locationsRaw, advertisingPlatformName, locationNames);
                }
            }

            var locations = GetLocations(locationsRaw, advertisingPlatforms);

            return new(advertisingPlatforms, locations);
        }

        private void AddLocationsRaw(Dictionary<string, string> locationsRawDictionary, string advertisingPlatformName, List<string> locationNames)
        {
            foreach (var locationName in locationNames)
            {
                locationsRawDictionary.Add(locationName, advertisingPlatformName);
            }
        }


        private List<Location> GetLocations(Dictionary<string, string> locationsRaw,
            List<AdvertisingPlatform> advertisingPlatforms)
        {
            var locations = locationsRaw
                .Select((x, Index) => new Location
                {
                    Id = Index + 1, 
                    Name = x.Key,
                    AdvertisingPlatformIds = GetDirectId(advertisingPlatforms, x.Value) > 0 ? [GetDirectId(advertisingPlatforms, x.Value)] : new()
                })
                .Select(x => new Location
                {
                    Id = x.Id,
                    Name = x.Name,
                    AdvertisingPlatformIds = x.AdvertisingPlatformIds.Concat(GetAdditionalIds(locationsRaw, advertisingPlatforms, x.Name)).ToList()
                })
                .ToList();

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
