namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// The type contains advertising and locations obtained from the file.
    /// </summary>
    public class AdvertisingInformation
    {
        /// <summary>
        /// Collection advertisingInLocations.
        /// </summary>
        public IReadOnlyList<AdvertisingInLocation> AdvertisingInLocations { get; }

        /// <summary>
        /// Collection advertising.
        /// </summary>
        public IReadOnlyList<AdvertisingPlatform> AdvertisingPlatforms { get; }

        /// <summary>
        /// Collection locations.
        /// </summary>
        public IReadOnlyList<Location> Locations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="advertisingInLocations">Collection AdvertisingInLocation</param>
        /// <param name="advertisingPlatforms">Collection advertising.</param>
        /// <param name="locations">Collection locations.</param>
        public AdvertisingInformation( 
            IReadOnlyList<AdvertisingInLocation> advertisingInLocations, 
            IReadOnlyList<AdvertisingPlatform> advertisingPlatforms, 
            IReadOnlyList<Location> locations)
        {
            AdvertisingInLocations = advertisingInLocations;
            AdvertisingPlatforms = advertisingPlatforms;
            Locations = locations;
        }
    }
}
