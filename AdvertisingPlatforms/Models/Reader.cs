
namespace AdvertisingPlatforms.Models
{
    public class Reader: IReader
    {
        public async Task<Dictionary<string, string>?> GetValidDataAsync(IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            try
            {
                //читаем весь файл в строку
                var fileData = await streamReader.ReadToEndAsync();

                //парсим строку
                Dictionary<string, string> resul = GetParseData(fileData);

                return resul;
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
    }
}
