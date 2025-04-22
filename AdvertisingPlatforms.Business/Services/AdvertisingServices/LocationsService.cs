using AdvertisingPlatforms.Business.Abstractions.Repositories;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
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

        public int ReplaceRepository(List<Location> newEntitiesList)
        {
            _locationRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count;
        }
    }
}
