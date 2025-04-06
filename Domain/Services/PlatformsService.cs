using Domain.Interfaces;

namespace Domain.Services
{
    public class PlatformsService : IPlatformsService
    {
        private Dictionary<string, List<string>> _db = new() 
        {
            //данные по умолчанию
            { "/ru", new List<string>{ "Яндекс.Директ" } },
            { "/ru/svrd/revda", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
            { "/ru/svrd/pervik", new List < string > { "Ревдинский рабочий", "Крутая реклама", "Яндекс.Директ" } },
            { "/ru/msk", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
            { "/ru/permobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
            { "/ru/chelobl", new List < string > { "Газета уральских москвичей", "Яндекс.Директ" } },
            { "/ru/svrd", new List < string > { "Крутая реклама", "Яндекс.Директ" } }
        };

        public List<string> GetPlatforms(string location)
        {
            List<string> result = new();

            bool findLocations = _db.TryGetValue(@"/" + location, out List<string>? value);

            if (findLocations && value?.Count > 0) 
            {
                result = value;
            }

            return result;
        }

        public int SetDbPlatforms(Dictionary<string, List<string>> db)
        {
            //устанавливаем новую базу
            _db = db;
            return _db.Count();
        }
    }
}
