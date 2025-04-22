using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    public interface IReplaceData<T> where T : notnull, Resource    
    {
        /// <summary>
        /// Set new entities for Service.
        /// </summary>
        /// <param name="newDb">New enities for replace.</param>
        public int ReplaceRepository(List<T> newEntitiesList);
    }
}
