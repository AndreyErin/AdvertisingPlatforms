namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for replaced data.
    /// </summary>
    /// <typeparam name="T">Type of data.</typeparam>
    public interface IReplaceData<T>
    {
        /// <summary>
        /// Set new entities for Service.
        /// </summary>
        /// <param name="newDb">New enities for replace.</param>
        public int ReplaceAllData(List<T> newEntitiesList);
    }
}
