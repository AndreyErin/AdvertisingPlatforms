using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Interfaces
{
    public interface IRepositoryWriter
    {
        public void SaveChangesToFile<TResource>(string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : Resource;

    }
}
