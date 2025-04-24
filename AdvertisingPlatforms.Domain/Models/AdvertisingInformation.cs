namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// The type contains advertising and locations obtained from the file.
    /// </summary>
    public class AdvertisingInformation
    {
        /// <summary>
        /// Collection advertisings.
        /// </summary>
        public List<AdvertisingPlatform> AdvertisingPlatforms { get; }

        /// <summary>
        /// Collection locations.
        /// </summary>
        public List<Location> Locations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="advertisingPlatforms">Collection advertisings.</param>
        /// <param name="locations">Collection locations.</param>
        public AdvertisingInformation(List<AdvertisingPlatform> advertisingPlatforms, List<Location> locations)
        {
            AdvertisingPlatforms = advertisingPlatforms;
            Locations = locations;
        }
    }
}
