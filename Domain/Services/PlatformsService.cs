﻿using Domain.Interfaces;

namespace Domain.Services
{
    public class PlatformsService : IPlatformsService
    {
        private Dictionary<string, List<string>> _db;

        private IPlatformsRepository _platformsRepo;

        public PlatformsService(IPlatformsRepository platformsRepository)
        {
            _platformsRepo = platformsRepository;

            var db = _platformsRepo.GetDb();

            if (db != null) 
            {
                _db = db;
            }
            else
            {
                _db = new();
            }
        }

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

        public int SetDbPlatforms(Dictionary<string, List<string>> newDb)
        {
            //устанавливаем новую базу
            int setDbResult = _platformsRepo.SetDb(newDb);

            if (setDbResult == -1)
            {
                return 0;
            }
            else 
            {
                _db = newDb;
                return _db.Count();
            }       
        }
    }
}
