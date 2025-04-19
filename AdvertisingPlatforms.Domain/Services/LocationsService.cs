using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{
    public class LocationsService : ILocationsService
    {
        private FileRepository<Location> _locationRepository;
        public LocationsService(FileRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Location? GetByName(string name)
        {
            return _locationRepository.GetByNameFromRepository(name);
        }

        public int ReplaceAllData(List<Location> newEntitiesList)
        {
            _locationRepository.OwerwriteRepository(newEntitiesList);

            return newEntitiesList.Count;
        }
    }
}
