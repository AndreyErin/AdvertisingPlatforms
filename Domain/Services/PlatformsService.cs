using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class PlatformsService : IPlatformsService
    {
        private Dictionary<Location, List<Advertising>> _db = new();

        public int SetDbPlatforms(Dictionary<Location, List<Advertising>> db)
        {
            //устанавливаем новую базу
            _db = db;
            return _db.Count();
        }

        List<Advertising> IPlatformsService.GetPlatforms(string location)
        {
            List<Advertising> result = new();

            Location loc = new Location() { Name = @"/" + location };

            bool successFind = _db.TryGetValue(loc, out List<Advertising>? outResult);

            if (successFind && outResult?.Count > 0) 
            {
                result = outResult;
            }

            return result;
        }

    }
}
