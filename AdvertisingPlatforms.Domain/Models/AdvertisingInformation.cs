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
        public IReadOnlyList<AdvertisingPlatform> AdvertisingPlatforms { get; }

        /// <summary>
        /// Collection locations.
        /// </summary>
        public IReadOnlyList<Location> Locations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="advertisingPlatforms">Collection advertisings.</param>
        /// <param name="locations">Collection locations.</param>
        public AdvertisingInformation(IReadOnlyList<AdvertisingPlatform> advertisingPlatforms, IReadOnlyList<Location> locations)
        {
            AdvertisingPlatforms = advertisingPlatforms;
            Locations = locations;
        }
    }
}
