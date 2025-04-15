using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Reader for files containing information about advertising platforms.
    /// </summary>
    public class FileReader: IReader
    {
        public async Task<DataFromFile?> GetDataFromFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            try
            {
                var fileContent = await streamReader.ReadToEndAsync();

                //TODO - refactoring
                DataFromFile? result = ParseData(fileContent);

                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                //Loging
                return null;
            }
            catch (ObjectDisposedException)
            {
                //Loging
                return null;
            }
            catch (InvalidOperationException)
            {
                //Loging
                return null;
            }
            catch (Exception) 
            {
                //Loging, Horrified
                //Send on
                throw;
            }
        }

        //TODO - refatoring
        private DataFromFile? ParseData(string fileContent)
        {            
            List<AdvertisingPlatform> advertisingPlatforms = new();
            List<List<string>> groupedLocationNames = new();

            var fileRows = fileContent.Split("\r\n");

            foreach (var row in fileRows)
            {
                string[] platformAndLocations = row.Split(":");

                if (platformAndLocations.Length == 2)
                {
                    string advertisingPlatform = platformAndLocations[0].Trim();
                    advertisingPlatforms.Add(new() { Name = advertisingPlatform });

                    List<string> locationNames = platformAndLocations[1].Split(",").ToList();
                    groupedLocationNames.Add(locationNames);
                }
            }

            GenerateIdsForCollection(advertisingPlatforms);

            var locations = groupedLocationNames.SelectMany(x=>x.ToList())
                                             .Select(x=>new Location() { Name = x})
                                             .ToList();

            
            foreach (var location in locations)
            {
                for (int i = 0; i < advertisingPlatforms.Count; i++)
                {
                    if (groupedLocationNames[i].Contains(location.Name))
                    {
                        location.AdvertisingIPlatformds.Add(advertisingPlatforms[i].Id);
                    }
                }
            }

            foreach (var location in locations)
            {
                var AdvertisingPlatformIds = locations.Where(x => location.Name.Contains(x.Name) && x != location)
                                 .Select(x=>x.AdvertisingIPlatformds)
                                 .SelectMany(x=>x.ToList())
                                 .ToList();

                if (AdvertisingPlatformIds != null)
                {
                    location.AdvertisingIPlatformds.AddRange(AdvertisingPlatformIds);
                }
            }

            GenerateIdsForCollection(locations);

            DataFromFile result = new(advertisingPlatforms, locations);
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
    }
}
