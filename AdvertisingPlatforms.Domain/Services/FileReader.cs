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
                var fileData = await streamReader.ReadToEndAsync();

                //TODO - refactoring
                DataFromFile? result = GetParseData(fileData);

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
        private DataFromFile? GetParseData(string fileData)
        {            
            List<AdvertisingPlatform> advertisingPlatforms = new();
            List<List<string>> locationNamesList = new();

            var rowList = fileData.Split("\r\n");

            foreach (var row in rowList)
            {
                string[] rowFragments = row.Split(":");

                if (rowFragments.Length == 2)
                {
                    string advertisingPlatform = rowFragments[0].Trim();
                    advertisingPlatforms.Add(new() { Name = advertisingPlatform });

                    List<string> locationNames = rowFragments[1].Split(",").ToList();
                    locationNamesList.Add(locationNames);
                }
            }

            SetIndexesForCollection(advertisingPlatforms);

            var locations = locationNamesList.SelectMany(x=>x.ToList())
                                             .Select(x=>new Location() { Name = x})
                                             .ToList();

            foreach (var location in locations)
            {
                for (int i = 0; i < advertisingPlatforms.Count; i++)
                {
                    if (locationNamesList[i].Contains(location.Name))
                    {
                        location.AdvertisingIds.Add(advertisingPlatforms[i].Id);
                    }
                }
            }

            foreach (var location in locations)
            {
                var ids = locations.Where(x => location.Name.Contains(x.Name) && x != location)
                                 .Select(x=>x.AdvertisingIds)
                                 .SelectMany(x=>x.ToList())
                                 .ToList();

                if (ids != null)
                {
                    location.AdvertisingIds.AddRange(ids);
                }
            }

            SetIndexesForCollection(locations);

            DataFromFile result = new(advertisingPlatforms, locations);
            return result;
        }

        private List<T> SetIndexesForCollection<T>(List<T> collection) where T : notnull, Resource
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
