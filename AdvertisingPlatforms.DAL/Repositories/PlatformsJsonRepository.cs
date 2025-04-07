using AdvertisingPlatforms.Domain.Interfaces;
using System.Text.Json;

namespace AdvertisingPlatforms.DAL.Repositories
{
    public class PlatformsJsonRepository : IPlatformsRepository
    {
        private string filePath;

        public PlatformsJsonRepository()
        {
            filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\PlatformsDb.json";
        }

        public Dictionary<string, List<string>>? GetDb()
        {
            using StreamReader sr = new StreamReader(filePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonDb);

            return result;
        }

        public int SetDb(Dictionary<string, List<string>> newDb)
        {
            var newDbJson = JsonSerializer.Serialize(newDb);

            if (newDbJson == null) 
            {
                return -1;
            }

            using StreamWriter sw = new StreamWriter(filePath, false);

            sw.Write(newDbJson);

            return 1;
        }
    }
}
