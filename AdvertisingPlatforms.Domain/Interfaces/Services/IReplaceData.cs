namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    public interface IReplaceData<T>
    {
        /// <summary>
        /// Set new entities for Service.
        /// </summary>
        /// <param name="newDb">New enities for replace.</param>
        public int ReplaceAllData(List<T> newEntitiesList);
    }
}
