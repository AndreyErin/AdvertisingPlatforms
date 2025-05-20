using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Interfaces
{
    /// <summary>
    /// Interface for replace repository.
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public interface IReplaceData<TResource> where TResource : Resource    
    {
        /// <summary>
        /// Set new entities for Service.
        /// </summary>
        /// <param name="newEntitiesList">New entities for replace.</param>
        public int ReplaceRepository(IReadOnlyList<TResource> newEntitiesList);
    }
}
