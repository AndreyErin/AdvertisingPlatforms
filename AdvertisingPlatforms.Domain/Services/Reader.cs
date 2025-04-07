using AdvertisingPlatforms.Domain.Interfaces;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Reader for files containing information about advertising platforms.
    /// </summary>
    public class Reader: IReader
    {
        public async Task<Dictionary<string, List<string>>?> GetValidDataAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            try
            {
                var fileData = await streamReader.ReadToEndAsync();

                Dictionary<string, string> parseData = GetParseData(fileData);

                Dictionary<string, List<string>> result = GetFomatData(parseData);

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

        private Dictionary<string, List<string>> GetFomatData(Dictionary<string, string> data)
        {
            Dictionary<string, List<string>> result = new();

            foreach (var item in data) 
            {
                string key = item.Key;

                List<string> values = new() { item.Value };

                var execpValues = data.Where(x=> item.Key.Contains(x.Key) && x.Key != item.Key)
                                      .Select(x=>x.Value)
                                      .Distinct()
                                      .ToList();

                if(execpValues != null)
                {
                    values.AddRange(execpValues);
                }

                result.Add(key, values);
            }

            return result;
        }
    }
}
