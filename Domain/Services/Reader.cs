using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class Reader: IReader
    {
        public async Task<Dictionary<Location, List<Advertising>>?> GetValidDataAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            try
            {
                //читаем весь файл в строку
                var fileData = await streamReader.ReadToEndAsync();

                //парсим строку
                Dictionary<string, string> oldFormatData = GetParseData(fileData);

                Dictionary<Location, List<Advertising>> result = GetNewFormatData(oldFormatData);

                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                //Залогировали
                return null;
            }
            catch (ObjectDisposedException)
            {
                //Залогировали
                return null;
            }
            catch (InvalidOperationException)
            {
                //Залогировали
                return null;
            }
            catch (Exception) 
            {
                //Залогировали, ужаснулись
                //отправили дальше
                throw;
            }
        }

        private Dictionary<string, string> GetParseData(string fileData)
        {
            Dictionary<string, string>? result = new();

            var rowList = fileData.Split("\r\n");

            foreach (var row in rowList) 
            {
                string[] rowFragments = row.Split(":");

                if(rowFragments.Length == 2)
                {
                    string value = rowFragments[0].Trim();
                    string[] keys = rowFragments[1].Split(",");

                    foreach (var key in keys) 
                    {
                        result.Add(key.Trim(), value);
                    }
                }
            }

            return result;
        }

        private Dictionary<Location, List<Advertising>> GetNewFormatData(Dictionary<string, string> oldFormatData)
        {
            Dictionary<Location, List<Advertising>> result = new();

            foreach (var item in oldFormatData)
            {
                Location location = new Location() { Name = item.Key };
                List<Advertising> advertisingList = new List<Advertising>();
                advertisingList.Add(new() { Name = item.Value});

                var advertisings = oldFormatData.Where(x => item.Key.Contains(x.Key) && item.Key != x.Key ).Select(x=>x.Value).ToList();

                if (advertisings.Count > 0)
                {
                    foreach (var advertising in advertisings)
                    {
                        advertisingList.Add(new() { Name = advertising});
                    }
                }
                result.Add(location, advertisingList);
            }

            return result;
        }
    }
}
