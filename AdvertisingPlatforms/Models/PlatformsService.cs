
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;

namespace AdvertisingPlatforms.Models
{
    public class PlatformsService : IPlatformsService
    {
        private Dictionary<string, string> _db = new() 
        {
            { "/ru", "Яндекс.Директ" },
            { "/ru/svrd/revda", "Ревдинский рабочий" },
            { "/ru/svrd/pervik", "Ревдинский рабочий" },
            { "/ru/msk", "Газета уральских москвичей" },
            { "/ru/permobl", "Газета уральских москвичей" },
            { "/ru/chelobl", "Газета уральских москвичей" },
            { "/ru/svrd", "Крутая реклама" }

        };

        public List<string> GetPlatforms(string region)
        {
            //получаем список всех возможных локаций
            List<string> locations = GetLocations(region);

            List<string> result = new();
            foreach (string location in locations) 
            {
                var sub = _db.Where(x => x.Key == location).Select(x => x.Value).ToList();

                if (sub != null && sub.Count() > 0)
                {
                    result.AddRange(sub);
                }
            }

            //исключаем возможное дублирование
            result = result.Distinct().ToList();

            return result;
        }

        private List<string> GetLocations(string region)
        {
            string[] fragmentns = region.Split("/");

            List<string> result = new();
            string location = "";

            for (int i = 0; i < fragmentns.Length; i++)
            {
                location += @"/" + fragmentns[i];

                result.Add(location);
            }

            return result;
        }
 
        public int SetDbPlatforms(Dictionary<string, string> db)
        {
            //устанавливаем новую базу
            _db = db;
            return _db.Count();
        }
    }
}
