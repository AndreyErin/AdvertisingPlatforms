using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Information about the number of updated entities.
    /// </summary>
    public class AdvertisingUpdateResult: ApiResultData
    {
        /// <summary>
        /// Count of adds advertisings.
        /// </summary>
        public int CountAdvertisingPlatforms { get; }

        /// <summary>
        /// Count of adds locations.
        /// </summary>
        public int CountLocations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="countAdvertisingPlatforms">Count of adds advertisings.</param>
        /// <param name="countLocations">Count of adds locations.</param>
        public AdvertisingUpdateResult(int countAdvertisingPlatforms, int countLocations)
        {
            CountAdvertisingPlatforms = countAdvertisingPlatforms;
            CountLocations = countLocations;
        }
    }
}
