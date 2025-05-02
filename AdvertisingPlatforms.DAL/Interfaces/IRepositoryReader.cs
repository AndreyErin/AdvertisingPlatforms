using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Interfaces
{
    public interface IRepositoryReader
    {
        public List<TResource> GetAllFromFile<TResource>(string filePath) where TResource : Resource;

    }
}
