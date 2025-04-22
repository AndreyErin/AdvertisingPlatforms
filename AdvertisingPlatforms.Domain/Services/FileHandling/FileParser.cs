using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Services.FileHandling
{
    public class FileParser : IFileParser
    {
        public AdvertisingInformation GetParseData(string fileContent)
        {
            List<AdvertisingPlatform> advertisingPlatforms = new();
            List<List<string>> groupedLocationNames = new();

            var fileRows = fileContent.Split("\r\n");

            foreach (var row in fileRows)
            {
                var platformAndLocations = row.Split(":");

                if (platformAndLocations.Length == 2)
                {
                    var advertisingPlatform = platformAndLocations[0].Trim();
                    advertisingPlatforms.Add(new() { Name = advertisingPlatform });

                    var locationNames = platformAndLocations[1].Split(",").ToList();
                    groupedLocationNames.Add(locationNames);
                }
            }

            GenerateIdsForCollection(advertisingPlatforms);

            var locations = GetLocations(groupedLocationNames, advertisingPlatforms);
            GenerateIdsForCollection(locations);


            //TODO - проверка корректности данных

            AdvertisingInformation result = new(advertisingPlatforms, locations);

            return result;
        }

        private List<T> GenerateIdsForCollection<T>(List<T> collection) where T : notnull, Resource
        {
            int counter = 1;

            foreach (var element in collection)
            {
                element.Id = counter;
                counter++;
            }

            return collection.ToList();
        }

        private List<Location> GetLocations(List<List<string>> groupedLocationNames, List<AdvertisingPlatform> advertisingPlatforms)
        {
            var locations = groupedLocationNames.SelectMany(x => x)
                                 .Select(x => new Location() { Name = x })
                                 .ToList();

            foreach (var location in locations)
            {
                location.AdvertisingIPlatformds.AddRange(GetDirectIds(location, groupedLocationNames, advertisingPlatforms));
            }

            foreach (var location in locations)
            {
                location.AdvertisingIPlatformds.AddRange(GetAdditionlIds(locations, location, advertisingPlatforms));
            }

            return locations;
        }

        private List<int> GetDirectIds(Location location, List<List<string>> groupedLocationNames, List<AdvertisingPlatform> advertisingPlatforms)
        {
            List<int> result = new();

            for (int i = 0; i < advertisingPlatforms.Count; i++)
            {
                if (groupedLocationNames[i].Contains(location.Name))
                {
                    result.Add(advertisingPlatforms[i].Id);
                }
            }

            return result;
        }

        private List<int> GetAdditionlIds(List<Location> locations, Location currentLocation, List<AdvertisingPlatform> advertisingPlatforms)
        {
            var AdvertisingPlatformIds = locations.Where(x => currentLocation.Name.Contains(x.Name) && x != currentLocation)
                 .Select(x => x.AdvertisingIPlatformds)
                 .SelectMany(x => x.ToList())
                 .ToList();

            return AdvertisingPlatformIds;
        }
    }
}
