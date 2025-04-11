using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class PlatformsService : IPlatformsService
    {
        private Repository<Location> _locationsRepository;
        private Repository<Advertising> _advertisingsRepository;

        public PlatformsService(Repository<Location> locationsRepository, Repository<Advertising> advertisingsRepository)
        {
            _locationsRepository = locationsRepository;
            _advertisingsRepository = advertisingsRepository;
        }

        public List<string> GetPlatforms(string locationName)
        {
            List<string> result = new();

            var location = _locationsRepository.Get(locationName);

            if (location != null && location.AdvertisingIds != null)
            {
                //TODO разнести вложенность по методам
                foreach (var advId in location.AdvertisingIds)
                {
                    var advertising = _advertisingsRepository.Get(advId);

                    if (advertising != null)
                    {
                        result.Add(advertising.Name);
                    }
                }
            }

            return result;
        }

        public int SetDbPlatforms(Dictionary<string, List<string>> newDb)
        {
            var advertisings = newDb.SelectMany(x=>x.Value)
                                        .Distinct()
                                        .Select(x=> new Advertising() { Name = x})
                                        .ToList();
            _advertisingsRepository.OwerWriteRepository(advertisings);

            var locations = new List<Location>();
            foreach (var item in newDb)
            {
                var advertisingIds = _advertisingsRepository.GetAll()
                                                            .Join(item.Value, a=>a.Name, l=>l, (a,l)=> a.Id).ToList();

                locations.Add(new Location() { Name = item.Key, AdvertisingIds = advertisingIds});
            }

            _locationsRepository.OwerWriteRepository(locations);

            return _locationsRepository.GetAll().Count();    
        }
    }
}
