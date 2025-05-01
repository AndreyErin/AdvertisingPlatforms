using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Information about the number of updated entities.
    /// </summary>
    public class AdvertisingUpdateResult: BaseResponse
    {
        /// <summary>
        /// Count of adds advertising platforms.
        /// </summary>
        public int CountAdvertisingPlatforms { get; }

        /// <summary>
        /// Count of adds locations.
        /// </summary>
        public int CountLocations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="success">Success of fail response.</param>
        /// <param name="countAdvertisingPlatforms">Count of adds advertising platforms.</param>
        /// <param name="countLocations">Count of adds locations.</param>
        public AdvertisingUpdateResult(bool success, int countAdvertisingPlatforms, int countLocations) : base(success)
        {
            CountAdvertisingPlatforms = countAdvertisingPlatforms;
            CountLocations = countLocations;
        }
    }
}
