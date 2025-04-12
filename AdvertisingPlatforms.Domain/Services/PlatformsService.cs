using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{

    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class PlatformsService : IPlatformsService
    {
        private FileRepository<Location> _locationsRepository;
        private FileRepository<Advertising> _advertisingsRepository;

        public PlatformsService(FileRepository<Location> locationsRepository, FileRepository<Advertising> advertisingsRepository)
        {
            _locationsRepository = locationsRepository;
            _advertisingsRepository = advertisingsRepository;
        }

        public List<string> GetPlatforms(string locationName)
        {
            List<string> result = new();

            var location = _locationsRepository.GetByNameFromRepository(locationName);

            if (location != null && location.AdvertisingIds != null)
            {
                //TODO refactoring
                foreach (var advId in location.AdvertisingIds)
                {
                    var advertising = _advertisingsRepository.GetByIdFromRepository(advId);

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
            _advertisingsRepository.OwerWriteDbOfRepository(advertisings);

            var locations = new List<Location>();
            foreach (var item in newDb)
            {
                var advertisingIds = advertisings.Join(item.Value, a=>a.Name, l=>l, (a,l)=> a.Id).ToList();

                locations.Add(new Location() { Name = item.Key, AdvertisingIds = advertisingIds});
            }

            _locationsRepository.OwerWriteDbOfRepository(locations);

            return locations.Count();    
        }
    }
}
